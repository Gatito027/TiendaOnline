namespace TiendaOnline.Utility
{
    public static class ConfigExtensions
    {
        public static void ConfigurateExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            Utilities.AuthAPIBase = configuration["ServiceUrls:AuthAPI"];
        }
    }
}
