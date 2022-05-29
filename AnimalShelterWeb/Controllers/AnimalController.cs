using Microsoft.AspNetCore.Mvc;
using Core;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterWeb.Controllers
{
    public class AnimalController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var animals = DataAccess.GetAnimals();
            return View(animals);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            return View(animal);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Animal animal)
        {

            //DataAccess.SaveAnimal(animal);
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        { 
            DataAccess.SaveAnimal(animal);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            DataAccess.DeleteAnimal(animal);

            return Redirect("~/animal/");
        }
    }
}
