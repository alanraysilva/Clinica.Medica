using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.WebUI.Controllers;

public class TriagemController : Controller
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public TriagemController(IHttpClientFactory factory, IConfiguration config)
    {
        _http = factory.CreateClient();
        _baseUrl = config["ApiSettings:BaseUrl"]!;
    }
    public async Task<IActionResult> Iniciar()
    {
        var fila = await _http.GetFromJsonAsync<List<AtendimentoFilaDto>>($"{_baseUrl}/api/atendimento/fila/simples");
        ViewBag.Atendimentos = fila;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Iniciar(TriagemDto dto)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}/api/triagem/", dto);
        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError("", "Erro ao registrar triagem");
        return View(dto);
    }

    [HttpGet]
    public async Task<IActionResult> Buscar(int numero)
    {
        var paciente = await _http.GetFromJsonAsync<TriagemAtendimentoDto?>($"{_baseUrl}/api/triagem/buscar/{numero}");
        if (paciente == null) return NotFound();

        var especialidades = await _http.GetFromJsonAsync<List<EspecialidadeDto>>($"{_baseUrl}/api/especialidade");

        ViewBag.Especialidades = especialidades;

        return PartialView("_TriagemPaciente", paciente);
    }
}