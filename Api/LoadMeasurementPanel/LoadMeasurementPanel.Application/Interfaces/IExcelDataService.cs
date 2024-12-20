﻿using LoadMeasurementPanel.Application.Dtos;

namespace LoadMeasurementPanel.Application.Interfaces
{
    public interface IExcelDataService
    {
        Task RecordExcelData(IEnumerable<ExcelDataDto> excelData);
        Task<ExcelDataDto> GetMeasurementDailyRegister(string pointName, DateTime searchDate);
    }
}
