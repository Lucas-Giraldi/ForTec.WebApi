using ForTec.Application.DTOs;
using ForTec.Domain.Entities;

namespace ForTec.Application.Services;

public interface ISolicitanteService
{
    Task<List<SolicitanteDto>> GetAll();
}
