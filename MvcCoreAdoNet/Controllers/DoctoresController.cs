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

        public IActionResult IndexOneModel()
        {
            ModelDoctores modelo = new ModelDoctores();
            modelo.Doctores = this.repo.GetDoctores();
            modelo.Especialidades = this.repo.GetEspecialidades();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult IndexOneModel(string? especialidad)
        {
            ModelDoctores modelo = new ModelDoctores();
            modelo.Especialidades = this.repo.GetEspecialidades();
            if (especialidad != null)
                modelo.Doctores = this.repo.GetDoctoresPorEspecialidad(especialidad);
            else
                modelo.Doctores = this.repo.GetDoctores();
            return View(modelo);
        }

        public IActionResult IndexViewData()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult IndexViewData(string? especialidad)
        {
            List<Doctor> doctores;
            ViewData["ESPECIALIDADES"] = this.repo.GetEspecialidades();
            if (especialidad != null)
                doctores = this.repo.GetDoctoresPorEspecialidad(especialidad);
            else
                doctores = this.repo.GetDoctores();
            return View(doctores);
        }
    }
}
