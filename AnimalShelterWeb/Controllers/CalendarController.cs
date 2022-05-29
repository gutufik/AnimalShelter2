using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace AnimalShelterWeb.Controllers
{
    public class CalendarController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var appointments = DataAccess.GetAnimalAppointments();
            return View(appointments);
        }
        public IActionResult Delete(int id)
        {
            var appointment = DataAccess.GetAnimalAppointment(id);
            DataAccess.DeleteAnimalAppointment(appointment);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        { 
            return View();
        }
    }
}
