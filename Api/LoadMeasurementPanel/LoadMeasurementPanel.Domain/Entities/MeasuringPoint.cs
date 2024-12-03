using System.ComponentModel.DataAnnotations;

namespace LoadMeasurementPanel.Domain.Entities
{
    public class MeasuringPoint
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
