using AutoMapper;
using LoadMeasurementPanel.Application.Dtos;
using LoadMeasurementPanel.Domain.Entities;

namespace LoadMeasurementPanel.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ExcelData, ExcelDataDto>().ReverseMap();
            CreateMap<RegisterExcelData, RegisterExcelDataDto>().ReverseMap();
        }
    }
}
