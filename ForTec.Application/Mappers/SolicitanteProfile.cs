using AutoMapper;
using ForTec.Application.DTOs;
using ForTec.Domain.Entities;

namespace ForTec.Application.Mappers;

public class SolicitanteProfile : Profile
{
    public SolicitanteProfile()
    {
        CreateMap<SolicitanteDto, SolicitanteEntity>()
            .ReverseMap();
    }
}
