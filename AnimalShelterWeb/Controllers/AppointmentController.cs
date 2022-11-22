using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using Core.Services;

namespace AnimalShelterWeb.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentService _appointmentService;
        public AppointmentController()
        {
            _appointmentService = new AppointmentService();
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Calendar");
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AnimalAppointment appointment)
        {
            _appointmentService.SaveAnimalAppointment(appointment);
            return RedirectToAction("Index");
        }
    }
}
