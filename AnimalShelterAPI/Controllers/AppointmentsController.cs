using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core;
using Core.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        // GET: api/<AppointmentsController>
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentModel>> Get()
        {
            var appointments = DataAccess.GetAnimalAppointments().Select(aa => new AppointmentModel(aa));
            if (appointments == null)
                return NoContent();

            return Ok(appointments);
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public ActionResult<AppointmentModel> Get(int id)
        {
            var appointment = new AppointmentModel(DataAccess.GetAnimalAppointment(id));
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentModel model)
        {
            DataAccess.SaveAnimalAppointment(new AnimalAppointment(model));
            return Ok();
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public ActionResult<AnimalAppointment> Put(int id, [FromBody] AppointmentModel model)
        {
            model.Id = id;

            if (DataAccess.GetAnimalAppointment(id) == null)
                return BadRequest();

            DataAccess.UpdateAppointment(new AnimalAppointment(model));
            return Ok(new AppointmentModel(DataAccess.GetAnimalAppointment(id)));
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var appointment = DataAccess.GetAnimalAppointment(id);
            if (appointment == null)
                return BadRequest();

            DataAccess.DeleteAnimalAppointment(appointment);
            return Ok();
        }
    }
}
