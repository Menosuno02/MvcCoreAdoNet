using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospital repo;

        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }

        public IActionResult Index(int? idhospitalEliminar)
        {
            if (idhospitalEliminar != null)
            {
                this.repo.DeleteHospital(idhospitalEliminar.Value);
            }
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int idhospital)
        {
            Hospital hospital = this.repo.FindHospitalById(idhospital);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repo.InsertHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital insertado";
            return View();
        }

        public IActionResult Update(int idhospital)
        {
            Hospital hospital = this.repo.FindHospitalById(idhospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            this.repo.UpdateHospital(hospital);
            ViewData["MENSAJE"] = "Hospital actualizado";
            return RedirectToAction("Index");
        }
    }
}
