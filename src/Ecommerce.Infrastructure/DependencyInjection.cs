using Ecommerce.Application.Common.Interfaces.Repositories;
using Ecommerce.Application.Common.Interfaces.Services;
using Ecommerce.Infrastructure.Persistence.Context;
using Ecommerce.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ecommerce.Infrastructure.Extensions.Authentication;

namespace Ecommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        services.
            AddPersitence(configuration);


        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static void AddPersitence(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        if (connectionString is null)
        {
            throw new ArgumentNullException("Connection string not found");
        }

        services.AddDbContext<EcommerceDbContext>(options =>
            options.UseSqlServer(connectionString, providerOptions =>
            {
                providerOptions.EnableRetryOnFailure().CommandTimeout(60);
            }));


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
