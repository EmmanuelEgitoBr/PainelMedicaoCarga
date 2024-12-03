namespace LoadMeasurementPanel.Application.Utils
{
    public static class MathFunctions
    {
        public static decimal GetAverageEnergyConsumptionPerDay(List<decimal> measures)
        {
            decimal total = 0;

            foreach (var item in measures)
            {
                total = total + item;
            }
            return Math.Round(total / 24, 2);
        }

        public static decimal GetTotalEnergyConsumptionPerDay(List<decimal> measures)
        {
            decimal total = 0;

            foreach (var item in measures)
            {
                total = total + item;
            }
            return Math.Round(total, 2);
        }

        public static int GetNumberHoursWithoutConsumption(List<decimal> measures)
        {
            int total = 0;

            foreach (var item in measures)
            {
                if (item == 0)
                {
                    total++;
                }
            }
            return total;
        }
    }
}
