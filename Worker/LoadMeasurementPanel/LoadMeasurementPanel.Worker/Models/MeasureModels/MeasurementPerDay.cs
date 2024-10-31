namespace LoadMeasurementPanel.Worker.Models.MeasureModels
{
    public class MeasurementPerDay
    {
        public int Id { get; set; }
        public int MeasuringPointId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public List<decimal> Measurements { get; set; }
        public int NumberOfZeroHours { get; set; }
        public int TotalConsumptionPerDay { get; set; }
    }
}
