namespace LoadMeasurementPanel.Web.Models
{
    public class EnergyConsumptionPerDay
    {
        public long Id { get; set; }
        public long MeasuringPointId { get; set; }
        public decimal TotalConsumption { get; set; }
        public decimal AverageConsumption { get; set; }
        public int HoursWithoutRegistration { get; set; }
    }
}
