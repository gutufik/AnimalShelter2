using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace AnimalShelterWeb.Controllers
{
    public class AppointmentController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AnimalAppointment appointment)
        {
            DataAccess.SaveAnimalAppointment(appointment);
            return RedirectToAction("Index");
        }
    }
}
