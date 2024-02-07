using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaMascotas()
        {
            List<Mascota> mascotas = new List<Mascota>();
            mascotas.Add(new Mascota("TRASTO", "GATO", "EUROPEO", 10));
            mascotas.Add(new Mascota("CUQUI", "GATO", "EUROPEO", 8));
            mascotas.Add(new Mascota("PIRATA", "PERRO", "CANICHE", 5));
            mascotas.Add(new Mascota("LILO", "ERIZO", "AFRICANO", 4));
            return View(mascotas);
        }
    }
}
