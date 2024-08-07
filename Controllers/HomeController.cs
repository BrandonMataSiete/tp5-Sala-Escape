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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

    public ActionResult Habitacion(int sala)
    {
        if (sala != Escape.GetEstadoJuego())
        {
            sala = Escape.GetEstadoJuego();
            ViewBag.Error = "Estás intentando resolver una sala incorrecta.";
        }

        return View($"Habitacion{sala}");
    }

    [HttpPost]
    public ActionResult Habitacion(int sala, string clave)
    {
        if (sala != Escape.GetEstadoJuego())
        {
            sala = Escape.GetEstadoJuego();
            ViewBag.Error = "Estás intentando resolver una sala incorrecta.";
            return View($"Habitacion{sala}");
        }

        if (Escape.ResolverSala(sala, clave))
        {
            if (Escape.GetEstadoJuego() > 5)
            {
                return RedirectToAction("Victoria");
            }
            return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
        }
        else
        {
            ViewBag.Error = "La respuesta es incorrecta. Inténtalo de nuevo.";
            return View($"Habitacion{sala}");
        }
    }

    public ActionResult Victoria()
    {
        return View();
    }
}
