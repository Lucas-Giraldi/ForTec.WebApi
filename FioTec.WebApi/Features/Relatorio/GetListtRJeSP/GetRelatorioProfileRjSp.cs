using AutoMapper;
using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Relatorio.GetListtRJeSP
{
    public class GetRelatorioProfileRjSp : Profile
    {
        public GetRelatorioProfileRjSp()
        {
            CreateMap<RelatorioDto, GetRelatorioResponseRjSp>()
                .ReverseMap();
        }
    }
}
