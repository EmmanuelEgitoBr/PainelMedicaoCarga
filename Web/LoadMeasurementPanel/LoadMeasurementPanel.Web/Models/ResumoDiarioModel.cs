namespace LoadMeasurementPanel.Web.Models
{
    public class ResumoDiarioModel
    {
        public long Id { get; set; }
        public string NomeMedidor { get; set; } = string.Empty;
        public decimal ConsumoTotal { get; set; }
        public decimal ConsumoMedio { get; set; }
        public int HorasSemRegistro { get; set; }
        public DateTime DataDaMedicao { get; set; }
    }
}
