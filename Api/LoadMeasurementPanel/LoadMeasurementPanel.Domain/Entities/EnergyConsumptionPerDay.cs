using System.ComponentModel.DataAnnotations;

namespace LoadMeasurementPanel.Domain.Entities
{
    public class EnergyConsumptionPerDay
    {
        [Key]
        public long Id { get; set; }
        public long MeasuringPointId { get; set; }
        public decimal TotalConsumption {  get; set; }
        public decimal AverageConsumption { get; set; }
        public int HoursWithoutRegistration { get; set; }
    }
}
