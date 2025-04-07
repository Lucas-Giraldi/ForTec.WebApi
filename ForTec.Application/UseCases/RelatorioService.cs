using AutoMapper;
using ForTec.Application.DTOs;
using ForTec.Application.Services;
using ForTec.Domain.Entities;
using ForTec.Domain.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace ForTec.Application.UseCases
{
    public class RelatorioService : IRelatorioService
    {


        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IMunicipioRepository _municipioRepository;

        public RelatorioService(ISolicitanteRepository solicitanteRepository, IRelatorioRepository relatorioRepository, IMapper mapper, HttpClient httpClient, IMunicipioRepository municipioRepository)
        {
            _solicitanteRepository = solicitanteRepository;
            _relatorioRepository = relatorioRepository;
            _mapper = mapper;
            _httpClient = httpClient;
            _municipioRepository = municipioRepository;
        }

        public async Task CreateRelatorio(CreateRelatorioDto request)
        {

            string url = $"https://info.dengue.mat.br/api/alertcity?" +
             $"geocode={request.CodigoIbge}&" +
             $"disease={request.Arbovirose.ToLower()}&format=json&" +
             $"ew_start={request.SemanaInicio}&ew_end={request.SemanaFim}&" +
             $"ey_start=2024&ey_end=2024";


            var response = await _httpClient.GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();

            var dados = JsonSerializer.Deserialize<List<RelatorioDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (dados == null || !dados.Any())
                throw new Exception("Nenhum dado encontrado na API.");

            var solicitanteExists = await _solicitanteRepository.VerifySolicitanteExists(request.Solicitante.Cpf);

            SolicitanteEntity solicitante;
            if (!solicitanteExists)
            {

                var newSolicitante = _mapper.Map<SolicitanteEntity>(request.Solicitante);
                await _solicitanteRepository.CreateSolicitante(newSolicitante);
                solicitante = newSolicitante;
            }
            else
            {
                solicitante = await _solicitanteRepository.GetByCpf(request.Solicitante.Cpf);
            }

            var municipio = await _municipioRepository.GetNameByCodIbge(request.CodigoIbge);

            if (municipio == null)
                throw new Exception("Município não encontrado para o código IBGE informado.");

            var relatorio = _mapper.Map<RelatorioEntity>(request);
            relatorio.SolicitanteId = solicitante.Id;
            relatorio.Solicitante = solicitante;
            relatorio.Municipio = municipio;
            var newRelatorio = await _relatorioRepository.CreateRelatorio(relatorio);
        }

        public async Task<List<RelatorioDto>> GetRelatorioByArbovirose(string arbovirose)
        {
            var relatorios = await _relatorioRepository.GetRelatorioByArbovirose(arbovirose);

            return _mapper.Map<List<RelatorioDto>>(relatorios);
        }

        public async Task<List<RelatorioDto>> GetRelatorioByCodeIbge(int code)
        {
           var relatorios = await _relatorioRepository.GetRelatorioByCodeIbge(code);
            return _mapper.Map<List<RelatorioDto>>(relatorios);
        }

        public async Task<List<RelatorioDto>> GetRelatoriosRioESaoPauloAsync()
        {
            var relatorios = await _relatorioRepository.GetRelatoriosRioESaoPauloAsync();

            return _mapper.Map<List<RelatorioDto>>(relatorios);
        }

        public async Task<int> GetRelatoriosRioESaoPauloTotalAsync()
        {
            return await _relatorioRepository.GetRelatoriosRioESaoPauloTotalAsync();
        }
    }
}
