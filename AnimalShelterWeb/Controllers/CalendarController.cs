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
    }
}
