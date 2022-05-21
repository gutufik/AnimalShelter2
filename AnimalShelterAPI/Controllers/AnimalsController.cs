using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            var animals = DataAccess.GetAnimals();
            foreach (var animal in animals)
                animal.Image = null;
            return animals;
        }

    }
}
