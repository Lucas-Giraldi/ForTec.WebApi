using AutoMapper;
using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Solicitantes.GetAll;

public class GetAllProfile : Profile
{
    public GetAllProfile()
    {
        CreateMap<SolicitanteDto, GetAllResponse>()
            .ReverseMap();
    }
}
