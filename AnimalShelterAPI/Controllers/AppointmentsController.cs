using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        // GET: api/<AppointmentsController>
        [HttpGet]
        public IEnumerable<AnimalAppointment> Get()
        {
            return DataAccess.GetAnimalAppointments();
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public AnimalAppointment Get(int id)
        {
            return DataAccess.GetAnimalAppointment(id);
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public void Post([FromBody] AnimalAppointment appointment)
        {
            DataAccess.SaveAnimalAppointment(appointment);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AnimalAppointment appointment)
        {
            appointment.Id = id;
            DataAccess.SaveAnimalAppointment(appointment);
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var appointment = DataAccess.GetAnimalAppointment(id);
            DataAccess.DeleteAnimalAppointment(appointment);
        }
    }
}
