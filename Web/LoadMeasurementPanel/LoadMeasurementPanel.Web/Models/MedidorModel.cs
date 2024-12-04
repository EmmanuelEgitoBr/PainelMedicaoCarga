namespace LoadMeasurementPanel.Web.Models
{
    public class MedidorModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
