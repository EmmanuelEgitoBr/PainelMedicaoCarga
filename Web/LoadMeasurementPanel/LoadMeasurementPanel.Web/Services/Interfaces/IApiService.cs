using LoadMeasurementPanel.Web.Models;

namespace LoadMeasurementPanel.Web.Services.Interfaces
{
    public interface IApiService
    {
        Task<ResumoDiarioModel> GetDailySummary(string pointName, string searchDate);
        Task<MedidasDiariaModel> GetDailyMeasures(string pointName, string searchDate);
        Task<InfoMedidoresModel> GetPointsInformations();
        Task<DetalhesMedidorModel> GetMeasurePointDetailsById(long id);
        Task<DetalhesMedidorModel> GetMeasurePointDetailsByName(string pointName);
        Task<List<MedidorModel>> GetAllPoints();
        Task<bool> DisableMeasurementPointByName(string pointName);
    }
}
