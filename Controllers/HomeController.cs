using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_sala_escape_Roballo_De_La_Fuente.Models;

namespace TP_sala_escape_Roballo_De_La_Fuente.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Tutorial()
    {
        return View();
    }

        public ActionResult Comenzar()
    {
        int sala = Escape.GetEstadoJuego();
        return RedirectToAction("Habitacion", new { sala = sala });
    }

    public ActionResult Habitacion(int sala, string? clave = null, string[]? incognitasSalas = null)
    {
        if (Request.Method == "GET")
        {
            if (sala != Escape.GetEstadoJuego())
            {
                sala = Escape.GetEstadoJuego();
                ViewBag.Error = "Estás intentando resolver una sala incorrecta.";
            }
            return View($"Habitacion{sala}");
        }

        if (sala != Escape.GetEstadoJuego())
        {
            sala = Escape.GetEstadoJuego();
            ViewBag.Error = "MAL. Estas jugando una sala incorrecta.";
            return View($"Habitacion{sala}");
        }

        if (Escape.ResolverSala(sala, clave!))
        {
            if (Escape.GetEstadoJuego() > incognitasSalas!.Length)
            {
                return RedirectToAction("Victoria");
            }
            return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
        }
        else
        {   
            ViewBag.Error = "MAL. Intente nuevamente";
            return View($"Habitacion{sala}");
        }
    }
}