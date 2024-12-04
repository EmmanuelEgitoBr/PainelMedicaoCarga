using LoadMeasurementPanel.Web.Configurations;
using LoadMeasurementPanel.Web.Services.Interfaces;
using LoadMeasurementPanel.Web.Services;

namespace LoadMeasurementPanel.Web.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            /*
            services.AddScoped<IApiService, ApiService>();

            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            services.AddHttpClient("ApiClient", client =>
            {
                var settings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
                client.BaseAddress = new Uri(settings!.BaseUrl);
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
            });
            */
            return services;
        }
    }
}
