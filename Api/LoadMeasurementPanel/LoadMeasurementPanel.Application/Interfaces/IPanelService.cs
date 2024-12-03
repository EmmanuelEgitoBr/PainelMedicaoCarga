namespace LoadMeasurementPanel.Application.Interfaces
{
    public interface IPanelService
    {
        Task CreateSummaryEnergyConsumptionPerDay();
        Task DeactivateMeasurementPoint(string name);
        Task UpdateMeasuringPointsList();
    }
}
