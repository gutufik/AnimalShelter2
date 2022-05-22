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
        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public Animal Get(int id)
        {
            return DataAccess.GetAnimal(id);
        }
        // POST api/<AppointmentsController>
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            DataAccess.SaveAnimal(animal);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.Id = id;
            DataAccess.SaveAnimal(animal);
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            DataAccess.DeleteAnimal(animal);
        }

    }
}
