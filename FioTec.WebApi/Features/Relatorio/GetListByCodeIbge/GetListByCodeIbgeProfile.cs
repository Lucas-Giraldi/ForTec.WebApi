using AutoMapper;
using FioTec.WebApi.Features.Relatorio.GetListtRJeSP;
using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Relatorio.GetListByCodeIbge
{
    public class GetListByCodeIbgeProfile : Profile
    {
        public GetListByCodeIbgeProfile()
        {
            CreateMap<RelatorioDto, GetListByCodeIbgeResponse>()
           .ReverseMap();
        }
    }
}
