using Microsoft.AspNetCore.Mvc;
using Core;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterWeb.Controllers
{
    public class MedicineController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var medicines = DataAccess.GetMedicines();
            return View(medicines);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

    }
}
