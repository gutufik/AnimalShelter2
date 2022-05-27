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
        public ActionResult<IEnumerable<AnimalModel>> Get()
        {
            var animals = DataAccess.GetAnimals().Select(x => new AnimalModel(x)); 

            if (animals == null)
                return NoContent();

            return Ok(animals);
        }
        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<AnimalModel> Get(int id)
        {
            var animal = new AnimalModel(DataAccess.GetAnimal(id));

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }
        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] AnimalModel model)
        {
            try
            {
                DataAccess.SaveAnimal(new Animal(model));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Animal> Put(int id, [FromBody] AnimalModel model)
        {
            model.Id = id;
            if (DataAccess.GetAnimal(id) == null)
                return BadRequest();
            try
            {
                DataAccess.UpdateAnimal(new Animal(model));
                return Ok(new AnimalModel(DataAccess.GetAnimal(id)));
            }
            catch
            {
                return BadRequest();
            }
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
