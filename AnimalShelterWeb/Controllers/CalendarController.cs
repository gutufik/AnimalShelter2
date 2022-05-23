using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterWeb.Controllers
{
    public class CalendarController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
