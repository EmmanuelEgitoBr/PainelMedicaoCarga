using AutoMapper;
using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Application.Interfaces;
using LoadMeasurementPanel.Application.Utils;
using LoadMeasurementPanel.Domain.Entities;
using LoadMeasurementPanel.Domain.Interfaces.MongoInterfaces;
using LoadMeasurementPanel.Domain.Interfaces.SqlInterfaces;

namespace LoadMeasurementPanel.Application.Services
{
    public class PanelService : IPanelService
    {
        private readonly IExcelDataRepository _excelDataRepository;
        private readonly IMeasuringPointRepository _measuringPointRepository;
        private readonly IConsumptionPerDayRepository _consumptionPerDayRepository;
        private readonly IMapper _mapper;

        public PanelService(IExcelDataRepository excelDataRepository,
                            IMeasuringPointRepository measuringPointRepository,
                            IConsumptionPerDayRepository consumptionPerDayRepository,
                            IMapper mapper)
        {
            _excelDataRepository = excelDataRepository;
            _measuringPointRepository = measuringPointRepository;
            _consumptionPerDayRepository = consumptionPerDayRepository;
            _mapper = mapper;
        }

        public async Task CreateSummaryEnergyConsumptionPerDay()
        {
            DateTime today = DateTime.Today;
            var register = await _excelDataRepository.FindAsync(r => r.DataRegistro >= today);

            foreach (var item in register!.Medicoes!) 
            {
                await GetEnergyConsumptionPerDay(item);
            }
        }

        public async Task DeactivateMeasurementPoint(string name)
        {
            var point = await _measuringPointRepository.GetAsync(p  => p.Name == name);
            point.IsActive = false;
            point.ActivationDate = DateTime.Now;
            _measuringPointRepository.Update(point);
        }

        public async Task<EnergyConsumptionPerDayDto> GetMeasurementSummary(string pointName, DateTime searchDate)
        {
            var nextDay = searchDate.AddDays(1);

            var measure = await _measuringPointRepository
                        .GetAsync(p => p.Name == pointName 
                        && p.ActivationDate >= searchDate && p.ActivationDate < nextDay);

            return _mapper.Map<EnergyConsumptionPerDayDto>(measure);
        }

        public async Task<MeasuringPointDetailsDto> GetMeasurementPointByNumber(string pointName)
        {
            var point = await _measuringPointRepository.GetAsync(p => p.Name == pointName);

            return new MeasuringPointDetailsDto
            {
                Name = point.Name,
                IsActive = (point.IsActive) ? "Ativo" : "Inativo",
                LastUpdate = point.ActivationDate
            };
        }

        public async Task<MeasuringPointInfoDto> GetMeasurementPointsInfo()
        {
            var points = await _measuringPointRepository.GetAllAsync();
            int total = points.Count();
            int inactive = 0;

            foreach (var point in points) 
            {
                if (!point.IsActive) { inactive++; }
            }

            return new MeasuringPointInfoDto
            {
                TotalNumber = total,
                NumberActivePoints = total - inactive,
                NumberInactivePoints = inactive
            };
        }

        public async Task UpdateMeasuringPointsList()
        {
            DateTime today = DateTime.Today;
            var register = await _excelDataRepository.FindAsync(r => r.DataRegistro >= today);
            List<MeasuringPoint> points = new List<MeasuringPoint>();

            if (register != null)
            {
                foreach (var item in register!.Medicoes!)
                {
                    var sqlPoint = await _measuringPointRepository
                        .GetAsync(p => p.Name == item.MeasurementPointName);

                    if (sqlPoint == null) 
                    {
                        MeasuringPoint point = new MeasuringPoint()
                        {
                            Name = item.MeasurementPointName,
                            IsActive = true,
                            ActivationDate = today
                        };
                        await _measuringPointRepository.CreateAsync(point);
                    }
                }
            }
        }

        private async Task GetEnergyConsumptionPerDay(ExcelData excelData)
        {
            var point = await _measuringPointRepository
                .GetAsync(p => p.Name == excelData.MeasurementPointName);

            EnergyConsumptionPerDay energy = new EnergyConsumptionPerDay()
            {
                MeasuringPointId = point.Id,
                TotalConsumption = MathFunctions
                            .GetTotalEnergyConsumptionPerDay(excelData.Measurements),
                AverageConsumption = MathFunctions
                            .GetAverageEnergyConsumptionPerDay(excelData.Measurements),
                HoursWithoutRegistration = MathFunctions
                            .GetNumberHoursWithoutConsumption(excelData.Measurements)
            };

            await _consumptionPerDayRepository.CreateAsync(energy);
        }
    }
}
