using LoadMeasurementPanel.Worker.Configuration;

namespace LoadMeasurementPanel.Worker.Services.Interfaces
{
    public interface IFtpService
    {
        Task ImportExcelFromFtpServer(FtpSettings settings);
    }
}
