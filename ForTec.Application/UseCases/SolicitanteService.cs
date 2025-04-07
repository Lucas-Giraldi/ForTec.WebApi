using AutoMapper;
using ForTec.Application.DTOs;
using ForTec.Application.Services;
using ForTec.Domain.Interfaces;

namespace ForTec.Application.UseCases;

public class SolicitanteService : ISolicitanteService
{
    private readonly ISolicitanteRepository _solicitanteRepository;
    private readonly IMapper _mapper;

    public SolicitanteService(ISolicitanteRepository solicitanteRepository, IMapper mapper)
    {
        _solicitanteRepository = solicitanteRepository;
        _mapper = mapper;
    }

    public async Task<List<SolicitanteDto>> GetAll()
    {
        var solicitantes = await _solicitanteRepository.GetAll();
        return _mapper.Map<List<SolicitanteDto>>(solicitantes);
    }
}
