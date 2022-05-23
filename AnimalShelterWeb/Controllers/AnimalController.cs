using Microsoft.AspNetCore.Mvc;
using Core;

namespace AnimalShelterWeb.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            var animals = DataAccess.GetAnimals();
            return View(animals);
        }
        public IActionResult Edit(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            return View(animal);
        }
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
