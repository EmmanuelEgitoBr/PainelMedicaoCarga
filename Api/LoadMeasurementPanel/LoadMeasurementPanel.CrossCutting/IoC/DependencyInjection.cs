using LoadMeasurementPanel.Application.Interfaces;
using LoadMeasurementPanel.Application.Mappings;
using LoadMeasurementPanel.Application.Services;
using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces;
using LoadMeasurementPanel.Infra.Configurations;
using LoadMeasurementPanel.Infra.Repositories.MongoDbRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace LoadMeasurementPanel.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExcelDataRepository, ExcelDataRepository>();
            services.AddScoped<IExcelDataService, ExcelDataService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }

        public static IServiceCollection AddSwaggerInfrastructure(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Controle de Medição de Energia Elétrica",
                    Description = "API REST desenvolvida em .NET Core, usando Clean Architeture" +
                        ", MongoDb e SQL Server como bancos de dados, feita para importar dados de medição de energia elétrica",
                    Contact = new OpenApiContact
                    {
                        Name = "Página de contato",
                        Url = new Uri("https://www.google.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licenciamento",
                        Url = new Uri("https://www.google.com")
                    }
                });
            });
            return services;
        }

        public static IServiceCollection AddMongoInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            MongoDbSettings mongoDBSettings = new MongoDbSettings
            {
                ConnectionString = configuration.GetSection("MongoDbSettings:ConnectionString").Value
                    ?? throw new InvalidOperationException("Configuração MongoDbSettings não foi informada"),
                DatabaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value
                    ?? throw new InvalidOperationException("Configuração MongoDbSettings não foi informada")
            };

            services.AddScoped(services => mongoDBSettings);

            services.AddScoped(provider => new MongoClient(mongoDBSettings.ConnectionString)
                                .GetDatabase(mongoDBSettings.DatabaseName));

            return services;
        }
    }
}
