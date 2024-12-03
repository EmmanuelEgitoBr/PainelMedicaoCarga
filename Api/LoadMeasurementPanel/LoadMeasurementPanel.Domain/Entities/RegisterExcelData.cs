namespace LoadMeasurementPanel.Domain.Entities
{
    public class RegisterExcelData
    {
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public IEnumerable<ExcelData>? Medicoes { get; set; }
    }
}
