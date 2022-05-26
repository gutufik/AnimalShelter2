using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            var animals = DataAccess.GetAnimals().Select(x => new AnimalModel(x)); 

            if (animals == null)
                return NoContent();

            return Ok(animals);
        }
        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            var animal = new AnimalModel(DataAccess.GetAnimal(id));

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }
        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] Animal animal)
        {
            DataAccess.SaveAnimal(animal);
            return Ok();
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Animal> Put(int id, [FromBody] Animal animal)
        {
            animal.Id = id;
            if (DataAccess.GetAnimal(id) == null)
                return BadRequest();

            DataAccess.SaveAnimal(animal);
            return Ok(new AnimalModel(DataAccess.GetAnimal(id)));
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            if (animal == null)
                return BadRequest();
            DataAccess.DeleteAnimal(animal);
            return Ok();
        }

    }
}
