using ClosedXML.Excel;
using FluentFTP;
using LoadMeasurementPanel.Worker.Configuration;
using LoadMeasurementPanel.Worker.Models;
using LoadMeasurementPanel.Worker.Models.MeasureModels;
using LoadMeasurementPanel.Worker.Services.Interfaces;
using LoadMeasurementPanel.Worker.Utils;

namespace LoadMeasurementPanel.Worker.Services
{
    public class FtpService : IFtpService
    {
        private ILogger<FtpService> _logger;
        private IApiService _apiService;

        public FtpService(ILogger<FtpService> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task ImportExcelFromFtpServer(FtpSettings settings)
        {
            using var ftpClient = new FtpClient(settings.Host, settings.Username, settings.Password);
            // Configurar o uso de TLS/SSL
            ftpClient.Config.EncryptionMode = FtpEncryptionMode.Explicit; // Usa FTPS explícito
            // Para ambientes de teste (remova em produção se possível)
            ftpClient.Config.ValidateAnyCertificate = true;

            var items = ftpClient.GetListing(settings.RemoteFileDirectory);
            string remotePath = "";
            string fileName = "";

            foreach (var item in items)
            {
                fileName = item.Name;
                remotePath = Path.Combine(settings.RemoteFileDirectory, fileName);
            }

            try
            {
                ftpClient.Connect();

                string localFilePath = Path.Combine(Path.GetTempPath(), "downloaded_file.xlsx");
                var downloadResult = ftpClient.DownloadFile(localFilePath, remotePath);

                if (downloadResult == FtpStatus.Success)
                {
                    _logger.LogInformation("Arquivo baixado com sucesso.");

                    var result = ProcessExcelFile(localFilePath, fileName);

                    if(result.Result!.Count() >= 0)
                    {
                        var apiResult = await _apiService.RecordExcelData(result.Result);
                    }

                    File.Delete(localFilePath);  // Deleta o arquivo local após o processamento
                }
                else
                {
                    _logger.LogWarning("Falha ao baixar o arquivo.");
                }

                ftpClient.Disconnect();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Erro ao se conectar com o serviço: {ex.Message}"); 
            }
            _logger.LogInformation("Fim de processamento");
        }

        private Response ProcessExcelFile(string filePath, string fileName)
        {
            DateTime measurementDate = FileUtils.GetDataFromFileName(fileName);
            var measuresList = new List<DailyEnergy>();

            try
            {
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);  // Seleciona a primeira planilha

                foreach (var row in worksheet.RowsUsed())
                {
                    DailyEnergy measurementPerDay = new DailyEnergy();
                    // Processa as células conforme necessário
                    var pointName = row.Cell(1).GetValue<string>();
                    _logger.LogInformation($"Valor da célula: {pointName}");

                    measurementPerDay.MeasurementPointName = pointName;

                    for (int i = 2; i < 26; i++)
                    {
                        measurementPerDay.Measurements.Add(row.Cell(i).GetValue<decimal>());
                    }

                    measurementPerDay.MeasurementDate = measurementDate;

                    measuresList.Add(measurementPerDay);
                }
                
                _logger.LogInformation("Processamento do arquivo Excel concluído.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao processar o arquivo Excel: {ex.Message}");
            }

            return new Response(measuresList, "Ok");
        }
    }
}
