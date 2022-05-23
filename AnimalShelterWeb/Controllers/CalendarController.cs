using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterWeb.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
