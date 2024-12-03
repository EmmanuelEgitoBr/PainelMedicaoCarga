namespace LoadMeasurementPanel.Application.Dtos
{
    public class EnergyConsumptionPerDayDto
    {
        public long Id { get; set; }
        public long MeasuringPointId { get; set; }
        public decimal TotalConsumption { get; set; }
        public decimal AverageConsumption { get; set; }
        public int HoursWithoutRegistration { get; set; }
    }
}
