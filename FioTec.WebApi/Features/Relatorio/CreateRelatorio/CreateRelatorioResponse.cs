namespace FioTec.WebApi.Features.Relatorio.CreateRelatorio
{
    public class CreateRelatorioResponse
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public string Arbovirose { get; set; }
        public int CodigoIbge { get; set; }
        public string Municipio { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }

        public SolicitanteResponse Solicitante { get; set; }
    }
}
