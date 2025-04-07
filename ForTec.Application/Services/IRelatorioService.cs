using ForTec.Application.DTOs;
using ForTec.Domain.Entities;

namespace ForTec.Application.Services;

public interface IRelatorioService
{
    Task<List<RelatorioDto>> GetRelatoriosRioESaoPauloAsync();
    Task<int> GetRelatoriosRioESaoPauloTotalAsync();

    Task<List<RelatorioDto>> GetRelatorioByCodeIbge(int code);

    Task<List<RelatorioDto>> GetRelatorioByArbovirose(string arbovirose);

    Task CreateRelatorio(CreateRelatorioDto relatorioEntity);
}
