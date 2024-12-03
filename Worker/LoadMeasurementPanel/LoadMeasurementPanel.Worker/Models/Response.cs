using LoadMeasurementPanel.Worker.Models.MeasureModels;

namespace LoadMeasurementPanel.Worker.Models
{
    public class Response(List<DailyEnergy> result, string? message)
    {
        public List<DailyEnergy> Result { get; set; } = result;
        public string? Message { get; set; } = message;
    }
}
