using LoadMeasurementPanel.Application.Dtos;

namespace LoadMeasurementPanel.Application.Interfaces
{
    public interface IPanelService
    {
        Task CreateSummaryEnergyConsumptionPerDay();
        Task DeactivateMeasurementPoint(string name);
        Task<EnergyConsumptionPerDayDto> GetMeasurementSummary(string pointName, DateTime searchDate);
        Task<MeasuringPointDetailsDto> GetMeasurementPointByNumber(string pointName);
        Task<MeasuringPointInfoDto> GetMeasurementPointsInfo();
        Task UpdateMeasuringPointsList();
    }
}
