using ClosedXML.Excel;
using FluentFTP;
using LoadMeasurementPanel.Worker.Models;
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

        private Response ProcessExcelFile(string filePath)
        {
            var measuresList = new List<MeasurementPerDay>();

            try
            {
                using var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);  // Seleciona a primeira planilha

                foreach (var row in worksheet.RowsUsed())
                {
                    // Processa as células conforme necessário
                    var cellValue = row.Cell(1).GetValue<string>();
                    _logger.LogInformation($"Valor da célula: {cellValue}");
                }
                foreach (var row in worksheet.RangeUsed().RowsUsed())
                {
                    MeasurementPerDay measurementPerDay = new MeasurementPerDay();

                    foreach (var cell in row.Cells())
                    {

                        Console.Write(cell.Value + "\t");
                    }
                    Console.WriteLine();
                }

                _logger.LogInformation("Processamento do arquivo Excel concluído.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao processar o arquivo Excel: {ex.Message}");
            }

            return 
        }
    }
}
