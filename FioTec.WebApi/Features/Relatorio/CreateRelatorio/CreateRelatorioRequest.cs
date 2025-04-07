using ForTec.Domain.Enums;

namespace FioTec.WebApi.Features.Relatorio.CreateRelatorio
{
    public class CreateRelatorioRequest
    {
        public int CodigoIbge { get; set; }
        public TipoRelatorioEnum TipoRelatorio { get; set; }
        public SolicitanteRequest Solicitante { get; set; }
        public string Arbovirose { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
    }
}
