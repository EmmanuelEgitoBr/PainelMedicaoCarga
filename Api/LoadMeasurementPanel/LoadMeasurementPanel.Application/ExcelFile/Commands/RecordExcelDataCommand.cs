using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Application.Interfaces;
using MediatR;

namespace LoadMeasurementPanel.Application.ExcelFile.Commands
{
    public record RecordExcelDataCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public IEnumerable<ExcelDataDto>? Medicoes { get; set; } 
    }

    public class RecordExcelDataCommandHandler : IRequestHandler<RecordExcelDataCommand, string>
    {
        private readonly IExcelDataService _excelDataService;

        public RecordExcelDataCommandHandler(IExcelDataService excelDataService)
        {
            _excelDataService = excelDataService;
        }

        public async Task<string> Handle(RecordExcelDataCommand request, CancellationToken cancellationToken)
        {
            var register = new RegisterExcelDataDto()
            {
                Id = Guid.NewGuid(),
                DataRegistro = request.DataRegistro,
                Medicoes = request.Medicoes
            };

            await _excelDataService.RecordExcelData(register);

            return register.Id.ToString();
        }
    }
}
