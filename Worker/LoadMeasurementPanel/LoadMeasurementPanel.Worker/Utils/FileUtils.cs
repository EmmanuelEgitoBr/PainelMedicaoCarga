namespace LoadMeasurementPanel.Worker.Utils
{
    public static class FileUtils
    {
        public static DateTime GetDataFromFileName(string fileName)
        {
            var day = Convert.ToInt32(fileName.Substring(7, 2));
            var month = Convert.ToInt32(fileName.Substring(9, 2));
            var year = Convert.ToInt32(fileName.Substring(11, 4));

            return new DateTime(year, month, day);
        }
    }
}
