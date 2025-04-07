using AutoMapper;
using FioTec.WebApi.Features.Solicitantes.GetAll;
using ForTec.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FioTec.WebApi.Features.Solicitantes
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitanteController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;
        private readonly IMapper _mapper;

        public SolicitanteController(ISolicitanteService solicitanteService, IMapper mapper)
        {
            _solicitanteService = solicitanteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todos os solicitantes.
        /// </summary>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<GetAllResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var solicitantes = await _solicitanteService.GetAll();

            if (!solicitantes.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<List<GetAllResponse>>(solicitantes));
        }
    }
}
