using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Services
{
    public class MedicineService
    {
        private DataAccess _dataAccess;
        public MedicineService()
        { 
            _dataAccess = new DataAccess();
        }
        public List<Medicine> GetMedicines()
        { 
            return _dataAccess.GetMedicines();
        }
        public void SaveMedicine(Medicine medicine)
        {
            _dataAccess.SaveMedicine(medicine);
        }
        public void DeleteMedicine(Medicine medicine)
        {
            _dataAccess.DeleteMedicine(medicine);
        }
    }
}
