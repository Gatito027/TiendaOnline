using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using TiendaOnline.Contract;
using TiendaOnline.Filters;
using TiendaOnline.Services;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Utility
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.AddControllers(option =>
            {
                option.Filters.Add<CustomExeceptionFilterAttribute>();
            });
            services.AddHttpContextAccessor();
            //Configurción de HttpClient con tiempo de vida optimo
            services.AddHttpClient<IAuthServices, AuthServices>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
            //Inyeccion de dependencias
            //services.AddTransient<IDataCloudAzure, DataCloudAzure>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            // Configuración para subir archivos grandes
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10 MB
            });
            //Configuración de autenticación y cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/Denied";
                    options.SlidingExpiration = true; // Mantiene la sesión activa
                });
            //Configuración de autorización con políticas
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("RoleAdmin"));
            });
        }
    }
}
