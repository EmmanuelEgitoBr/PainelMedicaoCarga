namespace LoadMeasurementPanel.Domain.Entities
{
    public class MeasuringPoint
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
