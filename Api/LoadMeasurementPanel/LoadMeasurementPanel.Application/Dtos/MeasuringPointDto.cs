namespace LoadMeasurementPanel.Application.Dtos
{
    public class MeasuringPointDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}
