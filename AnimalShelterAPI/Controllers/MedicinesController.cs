using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Services;
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
        private MedicineService _medicineService;
        public MedicinesController()
        { 
            _medicineService =  new MedicineService();
        }

        // GET: api/<MedicinesController>
        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> Get()
        {
            var medicines = _medicineService.GetMedicines().Select(m => new MedicineModel(m));
            if (medicines == null)
                return NoContent();

            return Ok(medicines);
        }

        // POST api/<MedicinesController>
        [HttpPost]
        public ActionResult Post([FromBody] MedicineModel model)
        {
            _medicineService.SaveMedicine(new Medicine(model));
            return Ok();
        }
    }
}
