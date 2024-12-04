using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.API.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelFileController : ControllerBase
    {
        private IExcelDataService _excelService;

        public ExcelFileController(IExcelDataService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("gravar-dados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<string> RecordExcelDataInMongoDb(IEnumerable<ExcelDataDto> dados)
        {
            await _excelService.RecordExcelData(dados);

            return $"Foram inseridos com sucesso {dados.Count()} registros"; 
        }

        [HttpGet("buscar-registro/{nomeMedidor}/{dataBusca}")]
        public async Task<ExcelDataDto> GetDailyRegisterByDateAndPoint(string nomeMedidor, string dataBusca)
        {
            var searchDate = Convert.ToDateTime(dataBusca);

            return await _excelService.GetMeasurementDailyRegister(nomeMedidor, searchDate);
        }
    }
}
