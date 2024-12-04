namespace LoadMeasurementPanel.Web.Utils
{
    public static class Formatador
    {
        public static string FormatarDataParaApi(DateTime data)
        {
            return $"{data.Year}-{data.Month}-{data.Day}";
        }
    }
}
