using LoadMeasurementPanel.Worker.Configuration;
using LoadMeasurementPanel.Worker.Services.Interfaces;

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
                RemoteFileDirectory = _configuration.GetValue<string>("FtpSettings:RemoteFileDirectory")!
            };
            
            var hour = _configuration.GetValue<int>("Schedule:Hour");
            var minute = _configuration.GetValue<int>("Schedule:Minute");

            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                /*
                if (now.Hour == hour && now.Minute == minute)
                {
                    await _ftpService.ImportExcelFromFtpServer(ftpSettings);

                    await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                }
                */
                await _ftpService.ImportExcelFromFtpServer(ftpSettings);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
