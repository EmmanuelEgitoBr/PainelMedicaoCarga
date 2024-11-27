using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Models
{
    public class Response
    {
        public List<MeasurementPerDay> Result {  get; set; }
        public string? Message { get; set; }
    }
}
