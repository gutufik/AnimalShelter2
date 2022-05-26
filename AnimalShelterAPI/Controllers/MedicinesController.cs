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
    public class MedicinesController : ControllerBase
    {
        // GET: api/<MedicinesController>
        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> Get()
        {
            var medicines = DataAccess.GetMedicines().Select(m => new MedicineModel(m));
            if (medicines == null)
                return NoContent();

            return Ok(medicines);
        }

        // POST api/<MedicinesController>
        [HttpPost]
        public ActionResult Post([FromBody] Medicine medicine)
        {
            DataAccess.SaveMedicine(medicine);
            return Ok();
        }
    }
}
