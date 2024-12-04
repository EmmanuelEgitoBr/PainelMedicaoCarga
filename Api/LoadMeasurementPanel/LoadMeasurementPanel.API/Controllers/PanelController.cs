using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.API.Controllers
{
    [Route("api/painel")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        private readonly IPanelService _panelService;

        public PanelController(IPanelService panelService)
        {
            _panelService = panelService;
        }

        [HttpGet("medidores")]
        public async Task<List<MeasuringPointDto>> GetAllPoints()
        {
            return await _panelService.GetAllMeasurementPoints();
        }

        [HttpGet("resumo-diario/{nomeMedidor}/{dataAmostra}")]
        public async Task<EnergyConsumptionPerDayDto> GetEnergyConsumptionPerDay(string nomeMedidor,
                                                                                 string dataAmostra)
        {
            var searchDate = Convert.ToDateTime(dataAmostra);
            
            var result = await _panelService.GetMeasurementSummary(nomeMedidor, searchDate);

            return result;
        }

        [HttpGet("medidor/{id:long}")]
        public async Task<MeasuringPointDetailsDto> GetMeasurementPointById(long id)
        {
            return await _panelService.GetMeasurementPointById(id);
        }

        [HttpGet("medidor/{nomeMedidor}")]
        public async Task<MeasuringPointDetailsDto> GetMeasurementPointByNumber(string nomeMedidor)
        {
            return await _panelService.GetMeasurementPointByNumber(nomeMedidor);
        }

        [HttpGet("controle-pontos")]
        public async Task<MeasuringPointInfoDto> GetMeasurementPointsInfo()
        {
            return await _panelService.GetMeasurementPointsInfo();
        }

        [HttpPost("atualizar-medidores")]
        public async Task UpdateMeasuringPoints()
        {
            await _panelService.UpdateMeasuringPointsList();
        }

        [HttpPut("desativar-medidor/{nome}")]
        public async Task DisableMeasuringPoint(string nome)
        {
            await _panelService.DeactivateMeasurementPoint(nome);
        }

        [HttpPost("criar-registro-diario")]
        public async Task CreateDailyRegister()
        {
            await _panelService.CreateSummaryEnergyConsumptionPerDay();
        }
    }
}
