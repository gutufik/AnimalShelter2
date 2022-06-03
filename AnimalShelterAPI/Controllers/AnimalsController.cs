using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
using Core.Services;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private AnimalService _animalService;

        public AnimalsController()
        {
            _animalService = new AnimalService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalModel>> Get()
        {
            var animals = _animalService.GetAnimals()
                            .Select(a => new AnimalModel(a)); 

            if (animals == null)
                return NoContent();

            return Ok(animals);
        }
        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<AnimalModel> Get(int id)
        {
            var animal = new AnimalModel(_animalService.GetAnimal(id));

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
                _animalService.SaveAnimal(new Animal(model));
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
            if (_animalService.GetAnimal(id) == null)
                return BadRequest();
            try
            {
                _animalService.UpdateAnimal(new Animal(model));
                return Ok(new AnimalModel(_animalService.GetAnimal(id)));
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
            var animal = _animalService.GetAnimal(id);
            if (animal == null)
                return BadRequest();
            _animalService.DeleteAnimal(animal);
            return Ok();
        }

    }
}
