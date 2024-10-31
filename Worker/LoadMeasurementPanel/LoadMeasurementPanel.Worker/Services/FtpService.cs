using FluentFTP;
using LoadMeasurementPanel.Worker.Models.FtpModels;
using LoadMeasurementPanel.Worker.Models.MeasureModels;
using LoadMeasurementPanel.Worker.Services.Interfaces;

namespace LoadMeasurementPanel.Worker.Services
{
    public class FtpService : IFtpService
    {
        private ILogger<FtpService> _logger;

        public FtpService(ILogger<FtpService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<MeasurementPerDay>> ImportExcelFromFtpServer(FtpSettings settings)
        {
            using var ftpClient = new FtpClient(settings.Host, settings.Username, settings.Password);
            try
            {
                ftpClient.Connect();

                string localFilePath = Path.Combine(Path.GetTempPath(), "downloaded_file.xlsx");
                var downloadResult = ftpClient.DownloadFile(localFilePath, settings.RemoteFilePath);

                if (downloadResult == FtpStatus.Success)
                {
                    _logger.LogInformation("Arquivo baixado com sucesso.");

                    //ProcessExcelFile(localFilePath);

                    File.Delete(localFilePath);  // Deleta o arquivo local após o processamento
                }
                else
                {
                    _logger.LogWarning("Falha ao baixar o arquivo.");
                }

                ftpClient.Disconnect();
            }
            catch (Exception ex) { return null; }


            throw new NotImplementedException();
        }
    }
}
