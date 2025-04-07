using ForTec.Domain.Enums;

namespace ForTec.Application.DTOs;

public class CreateRelatorioDto
{
    public int CodigoIbge { get; set; }
    public TipoRelatorioEnum TipoRelatorio { get; set; }
    public SolicitanteDto Solicitante { get; set; }
    public string Arbovirose { get; set; }
    public int SemanaInicio { get; set; }
    public int SemanaFim { get; set; }
}
