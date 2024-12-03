using LoadMeasurementPanel.Worker.Configuration;
using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Services.Interfaces
{
    public interface IFtpService
    {
        Task ImportExcelFromFtpServer(FtpSettings settings);
    }
}
