using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Core;

namespace AnimalShelterTests
{
    [TestClass]
    public class AppointmentsTest
    {
        [TestMethod]
        public void CorrectSavingAndDeleting()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            AnimalAppointment appointment = new AnimalAppointment(DateTime.Now, animal);
            Assert.IsNotNull(appointment);

            {
                DataAccess.SaveAnimalAppointment(appointment);
                List<AnimalAppointment> appointments = DataAccess.GetAnimalAppointments();
                Assert.IsTrue(appointments.Contains(appointment));
            }

            {
                DataAccess.DeleteAnimalAppointment(appointment);
                List<AnimalAppointment> appointments = DataAccess.GetAnimalAppointments();
                Assert.IsFalse(appointments.Contains(appointment));
            }
        }

        [TestMethod]
        public void GetByIdRetursValue()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            AnimalAppointment appointment = new AnimalAppointment(DateTime.Now, animal);
            DataAccess.SaveAnimalAppointment(appointment);

            AnimalAppointment returnedAppointment = DataAccess.GetAnimalAppointment(appointment.Id);

            Assert.AreEqual(appointment, returnedAppointment);
        }

        [TestMethod]
        public void GetByIdReturnsNull()
        {
            int id = -1;

            AnimalAppointment returnedAppointment = DataAccess.GetAnimalAppointment(id);

            Assert.IsNull(returnedAppointment);
        }
    }
}
