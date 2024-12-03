using LoadMeasurementPanel.Application.Dtos;

namespace LoadMeasurementPanel.Application.Interfaces
{
    public interface IExcelDataService
    {
        Task RecordExcelData(RegisterExcelDataDto excelData);
    }
}
