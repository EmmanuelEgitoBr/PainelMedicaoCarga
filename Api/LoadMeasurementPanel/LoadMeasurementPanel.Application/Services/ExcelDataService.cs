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

        public async Task RecordExcelData(IEnumerable<ExcelDataDto> excelDataDto)
        {
            var register = new RegisterExcelDataDto();
            register.DataRegistro = DateTime.Now;
            register.Medicoes = excelDataDto;

            var excelDataEntity = _mapper.Map<RegisterExcelData>(register);

            await _excelDataRepository.CreateAsync(excelDataEntity);
        }

        public async Task<ExcelDataDto> GetMeasurementDailyRegister(string pointName, DateTime searchDate)
        {
            var nextDay = searchDate.AddDays(1);

            var registers = await _excelDataRepository
                .FindAsync(r => r.DataRegistro >= searchDate && r.DataRegistro < nextDay);

            var dailyRegisters = registers.Medicoes!
                .Where(m => m.MeasurementPointName == pointName).FirstOrDefault();

            return _mapper.Map<ExcelDataDto>(dailyRegisters);
        }
    }
}
