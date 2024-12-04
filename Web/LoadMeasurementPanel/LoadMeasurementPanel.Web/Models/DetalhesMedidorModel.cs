using System.Text.Json.Serialization;

namespace LoadMeasurementPanel.Web.Models
{
    public class DetalhesMedidorModel
    {
        public long Id { get; set; }
        [JsonPropertyName("nome")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string IsActive { get; set; } = string.Empty;

        [JsonPropertyName("dataUltimaAtualizacao")]
        public DateTime LastUpdate { get; set; }
    }
}
