using Microsoft.AspNetCore.Mvc;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterWeb.Controllers
{
    public class MedicineController : Controller
    {
        private MedicineService _medicineService;
        public MedicineController()
        {
            _medicineService = new MedicineService();
        }

        [Authorize]
        public IActionResult Index()
        {
            var medicines = _medicineService.GetMedicines();
            return View(medicines);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            _medicineService.SaveMedicine(medicine);
            return View(medicine);
        }
    }
}
