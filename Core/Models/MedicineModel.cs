using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MedicineModel
    {
        public MedicineModel(Medicine medicine)
        {
            Id = medicine.Id;
            Name = medicine.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
