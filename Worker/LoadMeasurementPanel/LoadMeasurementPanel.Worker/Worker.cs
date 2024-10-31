using LoadMeasurementPanel.Worker.Models;
using LoadMeasurementPanel.Worker.Models.FtpModels;
using LoadMeasurementPanel.Worker.Services.Interfaces;
using System.Xml.Serialization;

namespace LoadMeasurementPanel.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFtpService _ftpService;

        public Worker(ILogger<Worker> logger, 
                        IConfiguration configuration,
                        IFtpService ftpService)
        {
            _logger = logger;
            _configuration = configuration;
            _ftpService = ftpService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var ftpSettings = new FtpSettings()
            {
                Host = _configuration.GetValue<string>("FtpSettings:Host")!,
                Username = _configuration.GetValue<string>("FtpSettings:Username")!,
                Password = _configuration.GetValue<string>("FtpSettings:Password")!,
                RemoteFilePath = _configuration.GetValue<string>("FtpSettings:RemoteFilePath")!
            };
            
            var hour = _configuration.GetValue<int>("Schedule:Hour");
            var minute = _configuration.GetValue<int>("Schedule:Minute");

            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;

                if (now.Hour == hour && now.Minute == minute)
                {
                    var result = await _ftpService.ImportExcelFromFtpServer(ftpSettings);

                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                }

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
