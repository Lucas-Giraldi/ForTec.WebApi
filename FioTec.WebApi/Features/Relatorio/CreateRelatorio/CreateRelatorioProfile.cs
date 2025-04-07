using AutoMapper;
using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Relatorio.CreateRelatorio
{
    public class CreateRelatorioProfile : Profile
    {

        public CreateRelatorioProfile()
        {
            CreateMap<CreateRelatorioDto, CreateRelatorioRequest>()
                .ReverseMap();

            CreateMap<SolicitanteDto, SolicitanteRequest>()
                .ReverseMap();
        }
    }
}
