using AutoMapper;
using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Application.Interfaces;
using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces;

namespace LoadMeasurementPanel.Application.Services
{
    public class ExcelDataService : IExcelDataService
    {
        private readonly IExcelDataRepository _excelDataRepository;
        private readonly IMapper _mapper;

        public ExcelDataService(IExcelDataRepository excelDataRepository, IMapper mapper)
        {
            _excelDataRepository = excelDataRepository;
            _mapper = mapper;
        }

        public async Task RecordExcelData(RegisterExcelDataDto excelData)
        {
            excelData.DataRegistro = DateTime.Now;

            var excelDataEntity = _mapper.Map<RegisterExcelData>(excelData);

            await _excelDataRepository.CreateAsync(excelDataEntity);
        }
    }
}
