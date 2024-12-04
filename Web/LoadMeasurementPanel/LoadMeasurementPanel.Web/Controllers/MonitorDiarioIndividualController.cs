using LoadMeasurementPanel.Web.Services.Interfaces;
using LoadMeasurementPanel.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.Web.Controllers
{
    public class MonitorDiarioIndividualController : Controller
    {
        private readonly IApiService _apiService;

        public MonitorDiarioIndividualController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MontarInformacoes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MontarInformacoes(string nomeMedidor, DateTime dataRegistro) 
        {
            if (ModelState.IsValid)
            {
                string sData = Formatador.FormatarDataParaApi(dataRegistro);

                var result = await _apiService.GetDailySummary(nomeMedidor, sData);

                if (result == null) { return View(); }

                ViewBag.DataRegistro = Formatador.FormatarDataParaTela(dataRegistro);

                return View(result);
            }

            return View();
        }
    }
}
