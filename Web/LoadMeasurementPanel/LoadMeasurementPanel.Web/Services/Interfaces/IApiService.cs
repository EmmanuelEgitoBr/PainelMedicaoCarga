using LoadMeasurementPanel.Web.Models;

namespace LoadMeasurementPanel.Web.Services.Interfaces
{
    public interface IApiService
    {
        Task<ResumoDiarioModel> GetDailySummary(string pointName, string searchDate);
    }
}
