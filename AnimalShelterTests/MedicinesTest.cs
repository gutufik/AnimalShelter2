using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Core;
using Core.Services;

namespace AnimalShelterTests
{
    [TestClass]
    public class MedicinesTest
    {
        private MedicineService _medicineService;
        public MedicinesTest()
        { 
            _medicineService = new MedicineService();
        }

        [TestMethod]
        public void CorrectSavingAndDeleting()
        {
            Medicine medicine = new Medicine("Натрия хлорид");
            Assert.IsNotNull(medicine);

            {
                _medicineService.SaveMedicine(medicine);
                List<Medicine> medicines = _medicineService.GetMedicines();
                Assert.IsTrue(medicines.Contains(medicine));
            }

            {
                _medicineService.DeleteMedicine(medicine);
                List<Medicine> medicines = _medicineService.GetMedicines();
                Assert.IsFalse(medicines.Contains(medicine));
            }
        }
        [TestMethod]
        public void TryAddEqualMedicines()
        {
            Medicine medicine = new Medicine("Натрия хлорид");
            _medicineService.SaveMedicine(medicine);
            _medicineService.SaveMedicine(medicine);
            List<Medicine> medicines = _medicineService.GetMedicines()
                    .Where(m => m.Name == medicine.Name).ToList();
            Assert.AreEqual(1, medicines.Count);
        }
    }
}
