using Clinica.Medica.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Clinica.Medica.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public HomeController(IHttpClientFactory factory, IConfiguration config)
    {
        _http = factory.CreateClient();
        _baseUrl = config["ApiSettings:BaseUrl"]!;
    }

    public async Task<IActionResult> Index()
    {
        var totalPacientes = await _http.GetFromJsonAsync<int>($"{_baseUrl}/api/estatisticas/total-pacientes");
        var fila = await _http.GetFromJsonAsync<int>($"{_baseUrl}/api/estatisticas/fila");
        var emAtendimento = await _http.GetFromJsonAsync<int>($"{_baseUrl}/api/estatisticas/em-atendimento");
        var atendidosHoje = await _http.GetFromJsonAsync<int>($"{_baseUrl}/api/estatisticas/atendidos-hoje");

        var atividades = await _http.GetFromJsonAsync<List<AtividadeDto>>($"{_baseUrl}/api/estatisticas/ultimas-atividades");

        ViewBag.TotalPacientes = totalPacientes;
        ViewBag.Fila = fila;
        ViewBag.EmAtendimento = emAtendimento;
        ViewBag.AtendidosHoje = atendidosHoje;
        ViewBag.AtividadesRecentes = atividades;

        return View();
    }
}