using LoadMeasurementPanel.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.Web.Controllers
{
    public class MonitorDiarioIndividualController : Controller
    {
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
        public IActionResult MontarInformacoes(string nomeMedidor, DateTime dataRegistro) 
        {
            string sData = Formatador.FormatarDataParaApi(dataRegistro);
            var oi = "";
            return View();
        }
    }
}
