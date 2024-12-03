using LoadMeasurementPanel.Application.ExcelFile.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoadMeasurementPanel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelFileController : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;

        [HttpPost("gravar-dados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<string> RecordExcelData(RecordExcelDataCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
