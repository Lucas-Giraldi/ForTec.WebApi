using ForTec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTec.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<RelatorioEntity> CreateRelatorio(RelatorioEntity relatorio);
        Task<List<RelatorioEntity>> GetRelatoriosRioESaoPauloAsync();
        Task<List<RelatorioEntity>> GetRelatorioByCodeIbge(int code);

        Task<int> GetRelatoriosRioESaoPauloTotalAsync();
        Task<List<RelatorioEntity>> GetRelatorioByArbovirose(string arbovirose);
    }
}
