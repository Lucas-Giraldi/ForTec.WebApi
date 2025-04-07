using ForTec.Application.DTOs;

namespace FioTec.WebApi.Features.Relatorio.GetListByCodeIbge
{
    public class GetListByCodeIbgeResponse
    {
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public string CodigoIbge { get; set; }
        public string Municipio { get; set; }

        public SolicitanteDto Solicitante { get; set; }
    }
}
