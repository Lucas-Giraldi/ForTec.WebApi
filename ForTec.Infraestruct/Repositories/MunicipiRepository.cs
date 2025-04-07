using ForTec.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ForTec.Infraestruct.Repositories;

public class MunicipiRepository : IMunicipioRepository
{
    private readonly ForTecContext _context;

    public MunicipiRepository(ForTecContext context)
    {
        _context = context;
    }
    public async Task<string> GetNameByCodIbge(int codigoIbge)
    {
        return await _context.Municipio
            .AsNoTracking()
            .Where(p => p.Codigo == codigoIbge)
            .Select(p => p.Nome)
            .FirstOrDefaultAsync();
    }
}
