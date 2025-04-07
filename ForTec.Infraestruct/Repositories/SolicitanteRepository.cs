using ForTec.Domain.Entities;
using ForTec.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTec.Infraestruct.Repositories
{
    public class SolicitanteRepository : ISolicitanteRepository
    {

        private readonly ForTecContext _context;

        public SolicitanteRepository(ForTecContext context)
        {
            _context = context;
        }

        public async Task CreateSolicitante(SolicitanteEntity solicitante)
        {
            try
            {
                _context.Solicitante.Add(solicitante);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o solicitante: " + ex.Message);
            }
        }

        public Task<List<SolicitanteEntity>> GetAll()
        {
            return _context.Solicitante.ToListAsync();
        }

        public Task<SolicitanteEntity> GetByCpf(string cpf)
        {
            return _context.Solicitante
                .FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public Task<bool> VerifySolicitanteExists(string cpf)
        {
            return _context.Solicitante.AnyAsync(p => p.Cpf == cpf);
        }
    }
}
