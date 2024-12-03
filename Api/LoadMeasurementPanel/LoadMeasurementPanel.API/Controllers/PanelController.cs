using LoadMeasurementPanel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        private readonly IPanelService _panelService;

        public PanelController(IPanelService panelService)
        {
            _panelService = panelService;
        }

        [HttpPost("atualizar-medidores")]
        public async Task UpdateMeasuringPoints()
        {
            await _panelService.UpdateMeasuringPointsList();
        }

        [HttpPut("desativar-medidor/{nome:alpha}")]
        public async Task DisablemeasuringPoint(string nome)
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
