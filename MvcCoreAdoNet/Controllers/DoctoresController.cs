using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repo;
        public DoctoresController()
        {
            this.repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult Index(string? especialidad)
        {
            List<Doctor> doctores = new List<Doctor>();
            if (especialidad != null)
                doctores = this.repo.SearchDoctoresPorEspecialidad(especialidad);
            else
                doctores = this.repo.GetDoctores();
            return View(doctores);
        }
    }
}
