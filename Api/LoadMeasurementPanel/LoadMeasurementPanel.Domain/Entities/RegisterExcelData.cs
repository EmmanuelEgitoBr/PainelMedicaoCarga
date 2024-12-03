using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoadMeasurementPanel.Domain.Entities
{
    public class RegisterExcelData
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public IEnumerable<ExcelData>? Medicoes { get; set; }
    }
}
