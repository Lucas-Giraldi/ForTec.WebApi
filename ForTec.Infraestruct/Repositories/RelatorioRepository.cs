using ForTec.Domain.Entities;
using ForTec.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForTec.Infraestruct.Repositories;

public class RelatorioRepository : IRelatorioRepository
{

    private readonly ForTecContext _context;

    public RelatorioRepository(ForTecContext context)
    {
        _context = context;
    }
    public async Task<RelatorioEntity> CreateRelatorio(RelatorioEntity relatorio)
    {
        try
        {
            _context.Relatorio.Add(relatorio);
            await _context.SaveChangesAsync();

            return relatorio;
        }

        catch(Exception ex)
        {
            throw new Exception("Erro ao criar o relatório: " + ex.Message);
        }
    }

    public Task<List<RelatorioEntity>> GetRelatorioByArbovirose(string arbovirose)
    {
        return _context.Relatorio
            .Where(r => r.Arbovirose == arbovirose)
            .Include(r => r.Solicitante)
            .ToListAsync();
    }

    public async Task<List<RelatorioEntity>> GetRelatorioByCodeIbge(int code)
    {
        return await _context.Relatorio
            .Where(r => r.CodigoIbge == code)
            .Include(r => r.Solicitante)
            .ToListAsync();
    }

    public async Task<List<RelatorioEntity>> GetRelatoriosRioESaoPauloAsync()
    {
        return await _context.Relatorio
            .Where(r => r.CodigoIbge == 3304557 || r.CodigoIbge == 3550308)
            .Include(r => r.Solicitante)
            .ToListAsync();
    }

    public async Task<int> GetRelatoriosRioESaoPauloTotalAsync()
    {
       return await _context.Relatorio
            .Where(r => r.CodigoIbge == 3304557 || r.CodigoIbge == 3550308)
            .CountAsync();
    }
}
