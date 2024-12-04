using LoadMeasurementPanel.Application.Dtos;

namespace LoadMeasurementPanel.Application.Interfaces
{
    public interface IPanelService
    {
        Task CreateSummaryEnergyConsumptionPerDay();
        Task DeactivateMeasurementPoint(string name);
        Task<List<MeasuringPointDto>> GetAllMeasurementPoints();
        Task<EnergyConsumptionPerDayDto> GetMeasurementSummary(string pointName, DateTime searchDate);
        Task<MeasuringPointDetailsDto> GetMeasurementPointById(long id);
        Task<MeasuringPointDetailsDto> GetMeasurementPointByNumber(string pointName);
        Task<MeasuringPointInfoDto> GetMeasurementPointsInfo();
        Task UpdateMeasuringPointsList();
    }
}
