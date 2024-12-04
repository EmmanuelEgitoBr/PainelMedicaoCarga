namespace LoadMeasurementPanel.Web.Models
{
    public class ResumoDiarioModel
    {
        public decimal ConsumoTotal { get; set; }
        public decimal ConsumoMedio { get; set; }
        public int HorasSemRegistro { get; set; }
        public string NomeMedidor { get; set; } = string.Empty;
        public DateTime DataDaMedicao { get; set; }
        public List<decimal> Medidas { get; set; } = new List<decimal>();
    }
}
