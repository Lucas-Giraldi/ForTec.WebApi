using AutoMapper;
using FioTec.WebApi.Common;
using FioTec.WebApi.Features.Relatorio.CreateRelatorio;
using FioTec.WebApi.Features.Relatorio.GetListByArbovirose;
using FioTec.WebApi.Features.Relatorio.GetListByCodeIbge;
using FioTec.WebApi.Features.Relatorio.GetListtRJeSP;
using ForTec.Application.DTOs;
using ForTec.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;
    private readonly IMapper _mapper;

    public RelatorioController(IRelatorioService relatorioService, IMapper mapper)
    {
        _relatorioService = relatorioService;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo relatório epidemiológico.
    /// </summary>
    [HttpPost("Relatorio")]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRelatorio([FromBody] CreateRelatorioRequest request)
    {
        var validator = new CreateRelatorioRequestValidation();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Code = 400,
                Message = "Erro de validação",
                Data = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage))
            });

        var relatorio = _mapper.Map<CreateRelatorioDto>(request);
        await _relatorioService.CreateRelatorio(relatorio);

        return Created(string.Empty, new ApiResponse<string>
        {
            Success = true,
            Code = 201,
            Message = "Relatório criado com sucesso",
            Data = null
        });
    }

    /// <summary>
    /// Lista todos os relatórios do Rio de Janeiro e São Paulo.
    /// </summary>
    [HttpGet("RjSp")]
    [ProducesResponseType(typeof(ApiResponse<List<GetRelatorioResponseRjSp>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetRelatoriosRioESaoPaulo()
    {
        var relatorios = await _relatorioService.GetRelatoriosRioESaoPauloAsync();

        if (!relatorios.Any())
            return NoContent();

        return Ok(new ApiResponse<List<GetRelatorioResponseRjSp>>
        {
            Success = true,
            Code = 200,
            Message = "Relatórios encontrados com sucesso.",
            Data = _mapper.Map<List<GetRelatorioResponseRjSp>>(relatorios)
        });
    }

    /// <summary>
    /// Lista os relatórios por código IBGE.
    /// </summary>
    [HttpGet("cod-ibge/{code}")]
    [ProducesResponseType(typeof(ApiResponse<List<GetListByCodeIbgeResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetRelatoriosByCodeIbge([FromRoute] int code)
    {
        var validator = new GetListByCodeIbgeRequestValidator();
        var validationResult = await validator.ValidateAsync(code);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Code = 400,
                Message = "Código IBGE inválido.",
                Data = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage))
            });

        var relatorios = await _relatorioService.GetRelatorioByCodeIbge(code);

        if (!relatorios.Any())
            return NoContent();

        return Ok(new ApiResponse<List<GetListByCodeIbgeResponse>>
        {
            Success = true,
            Code = 200,
            Message = "Relatórios encontrados com sucesso.",
            Data = _mapper.Map<List<GetListByCodeIbgeResponse>>(relatorios)
        });
    }

    /// <summary>
    /// Retorna a quantidade total de relatórios do RJ e SP.
    /// </summary>
    [HttpGet("RjSp/Count")]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetRelatoriosRioESaoPauloCount()
    {
        var total = await _relatorioService.GetRelatoriosRioESaoPauloTotalAsync();

        if (total <= 0)
            return NoContent();

        return Ok(new ApiResponse<int>
        {
            Success = true,
            Code = 200,
            Message = "Total de relatórios encontrados com sucesso.",
            Data = total
        });
    }

    /// <summary>
    /// Lista os relatórios por tipo de arbovirose.
    /// </summary>
    [HttpGet("arbovirose/{arbovirose}")]
    [ProducesResponseType(typeof(ApiResponse<List<GetListByArboviroseResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetRelatoriosByArbovirose([FromRoute] string arbovirose)
    {
        var validator = new GetListByArboviroseRequestValidator();
        var validationResult = await validator.ValidateAsync(arbovirose);

        if (!validationResult.IsValid)
            return BadRequest(new ApiResponse<string>
            {
                Success = false,
                Code = 400,
                Message = "Arbovirose inválida.",
                Data = string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage))
            });

        var relatorios = await _relatorioService.GetRelatorioByArbovirose(arbovirose);

        if (!relatorios.Any())
            return NoContent();

        return Ok(new ApiResponse<List<GetListByArboviroseResponse>>
        {
            Success = true,
            Code = 200,
            Message = "Relatórios encontrados com sucesso.",
            Data = _mapper.Map<List<GetListByArboviroseResponse>>(relatorios)
        });
    }
}
