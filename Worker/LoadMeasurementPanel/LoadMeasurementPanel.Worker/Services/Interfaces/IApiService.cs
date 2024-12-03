using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> RecordExcelData(IEnumerable<DailyEnergy> measures);
    }
}
