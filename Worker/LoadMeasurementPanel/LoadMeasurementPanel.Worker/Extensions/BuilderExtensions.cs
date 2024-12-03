using LoadMeasurementPanel.Worker.Services.Interfaces;
using LoadMeasurementPanel.Worker.Services;
using LoadMeasurementPanel.Worker.Configuration;

namespace LoadMeasurementPanel.Worker.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IApiService, ApiService>();

            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

            services.AddHttpClient("ApiClient", client =>
            {
                var settings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
                client.BaseAddress = new Uri(settings!.BaseUrl);
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
            });

            return services;
        }
    }
}
