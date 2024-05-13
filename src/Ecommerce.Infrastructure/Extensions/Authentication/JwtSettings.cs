namespace Ecommerce.Infrastructure.Extensions.Authentication
{
    public class JwtSettings
    {
        public readonly string SectionName = "JwtSettings";
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpiryInMinutes { get; set; }
    }
}