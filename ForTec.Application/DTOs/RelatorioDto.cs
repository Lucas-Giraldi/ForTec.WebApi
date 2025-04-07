namespace ForTec.Application.DTOs;

public class RelatorioDto
{
    public DateTime DataSolicitacao { get; set; }
    public string Arbovirose { get; set; }
    public int SemanaInicio { get; set; }
    public int SemanaFim { get; set; }
    public string CodigoIbge { get; set; }
    public string Municipio { get; set; }

    public SolicitanteDto Solicitante { get; set; }
}


