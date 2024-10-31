using LoadMeasurementPanel.Worker.Models.FtpModels;
using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Services.Interfaces
{
    public interface IFtpService
    {
        Task<IEnumerable<MeasurementPerDay>> ImportExcelFromFtpServer(FtpSettings settings);
    }
}
