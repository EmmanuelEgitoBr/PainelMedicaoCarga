using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadMeasurementPanel.Domain.Entities
{
    [Table("PontosMedicao")]
    public class MeasuringPoint
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
