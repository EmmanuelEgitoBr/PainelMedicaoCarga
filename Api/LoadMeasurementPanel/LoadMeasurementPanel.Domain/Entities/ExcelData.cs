using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LoadMeasurementPanel.Domain.Entities
{
    public class ExcelData
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string MeasurementPointName { get; set; } = string.Empty;
        public List<decimal> Measurements { get; set; } = new List<decimal>();
        public DateTime MeasurementDate { get; set; }
    }
}
