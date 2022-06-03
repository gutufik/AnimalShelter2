using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core
{
    public partial class Medicine
    {
        public Medicine(string name)
        {
            Name = name;
        }

        public Medicine(MedicineModel model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
}
