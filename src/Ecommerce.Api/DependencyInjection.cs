namespace Ecommerce.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthorization();
            return services;
        }
    }
}