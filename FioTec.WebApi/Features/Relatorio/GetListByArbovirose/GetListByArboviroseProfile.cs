using AutoMapper;
using FioTec.WebApi.Features.Relatorio.GetListtRJeSP;
using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Relatorio.GetListByArbovirose
{
    public class GetListByArboviroseProfile : Profile
    {
        public GetListByArboviroseProfile()
        {
            CreateMap<RelatorioDto, GetListByArboviroseResponse>()
           .ReverseMap();
        }
    }
}
