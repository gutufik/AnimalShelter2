using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Core;

namespace AnimalShelterTests
{
    [TestClass]
    public class MedicinesTest
    {
        [TestMethod]
        public void CorrectSavingAndDeleting()
        {
            Medicine medicine = new Medicine("Натрия хлорид");
            Assert.IsNotNull(medicine);

            {
                DataAccess.SaveMedicine(medicine);
                List<Medicine> medicines = DataAccess.GetMedicines();
                Assert.IsTrue(medicines.Contains(medicine));
            }

            {
                DataAccess.DeleteMedicine(medicine);
                List<Medicine> medicines = DataAccess.GetMedicines();
                Assert.IsFalse(medicines.Contains(medicine));
            }
        }
    }
}
