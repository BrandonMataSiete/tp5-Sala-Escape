using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_sala_escape_Roballo_De_La_Fuente.Models;

namespace TP_sala_escape_Roballo_De_La_Fuente.Controllers
{
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
        public IActionResult Habitacion(int sala, string clave)
        {
            if (sala != Escape.GetEstadoJuego())
            {
                return RedirectToAction("Habitacion", new { sala = Escape.GetEstadoJuego() });
            }

            if (clave != null)
            {
                bool resuelta = Escape.ResolverSala(sala, clave);

                if (resuelta)
                {
                    if (sala == 4)
                    {
                        Escape.InicializarJuego();
                        return View("victoria");
                    }
                    else
                    {
                        return RedirectToAction("Habitacion", new { sala = sala + 1 });
                    }
                }
                else
                {
                    ViewBag.Error = "MAL. Intenta nuevamente";
                }
            }
        return View($"Habitacion{sala}");
        }

        public IActionResult Creditos()
        {
            return View();
        }
    }
}
