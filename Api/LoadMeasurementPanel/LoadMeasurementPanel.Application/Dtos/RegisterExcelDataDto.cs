namespace LoadMeasurementPanel.Application.Dtos
{
    public class RegisterExcelDataDto
    {
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public IEnumerable<ExcelDataDto>? Medicoes { get; set; }
    }
}
