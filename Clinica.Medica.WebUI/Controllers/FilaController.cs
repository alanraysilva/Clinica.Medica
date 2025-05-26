using Clinica.Medica.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.WebUI.Controllers;

public class FilaController : Controller
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public FilaController(IHttpClientFactory factory, IConfiguration config)
    {
        _http = factory.CreateClient();
        _baseUrl = config["ApiSettings:BaseUrl"]!;
    }

    public async Task<IActionResult> Index()
    {
        //var fila = await _http.GetFromJsonAsync<List<AtendimentoDto>>($"{_baseUrl}/api/atendimento/fila");
        var fila = await _http.GetFromJsonAsync<List<AtendimentosDto>>($"{_baseUrl}/api/atendimento/fila/completa");
        ViewBag.BaseUrl = _baseUrl;
        return View(fila);
    }
}