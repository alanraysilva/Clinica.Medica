using Clinica.Medica.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Clinica.Medica.WebUI.Controllers
{
    public class PacienteController : Controller
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public PacienteController(IHttpClientFactory factory, IConfiguration config)
        {
            _http = factory.CreateClient();
            _baseUrl = config["ApiSettings:BaseUrl"]!;
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = await _http.GetFromJsonAsync<List<PacienteDto>>($"{_baseUrl}/api/paciente");
            return View(pacientes);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(PacienteDto dto)
        {
            var response = await _http.PostAsJsonAsync($"{_baseUrl}/api/paciente", dto);
            if (response.IsSuccessStatusCode)
            {
                TempData["NotificationMessage"] = "Dados criados com sucesso!";
                TempData["NotificationType"] = "success"; // ou "error", "info", etc.
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                TempData["NotificationMessage"] = $"Erro ao criar registro. Conatate o Administrador";
                TempData["NotificationType"] = "error";
                return RedirectToAction("Index", "Home");

            }
            
        }
    }
}
