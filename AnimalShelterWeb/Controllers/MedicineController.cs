using Microsoft.AspNetCore.Mvc;
using Core;

namespace AnimalShelterWeb.Controllers
{
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            var medicines = DataAccess.GetMedicines();
            return View(medicines);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
