using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadMeasurementPanel.Domain.Entities
{
    [Table("ConsumoDiarioPorPonto")]
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
