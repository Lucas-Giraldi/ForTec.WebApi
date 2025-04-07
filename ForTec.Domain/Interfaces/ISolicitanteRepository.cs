using ForTec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTec.Domain.Interfaces
{
    public interface ISolicitanteRepository
    {
        Task<bool> VerifySolicitanteExists(string cpf);
        Task CreateSolicitante(SolicitanteEntity solicitante);
        Task<SolicitanteEntity> GetByCpf(string cpf);

        Task<List<SolicitanteEntity>> GetAll();
    }
}
