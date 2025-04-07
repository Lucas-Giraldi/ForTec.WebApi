using AutoMapper;
using ForTec.Application.DTOs;
using ForTec.Domain.Entities;

namespace ForTec.Application.Mappers;

public class RelatorioProfile : Profile
{
    public RelatorioProfile()
    {
        CreateMap<RelatorioEntity, RelatorioDto>()
            .ReverseMap();

        CreateMap<RelatorioEntity, CreateRelatorioDto>()
            .ReverseMap();
    }
}
