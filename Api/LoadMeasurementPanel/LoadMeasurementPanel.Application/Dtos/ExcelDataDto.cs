﻿namespace LoadMeasurementPanel.Application.Dtos
{
    public class ExcelDataDto
    {
        public Guid Id { get; set; }
        public string MeasurementPointName { get; set; } = string.Empty;
        public List<decimal> Measurements { get; set; } = new List<decimal>();
        public DateTime MeasurementDate { get; set; }
    }
}
