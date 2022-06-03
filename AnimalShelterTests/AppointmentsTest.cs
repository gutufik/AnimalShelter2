using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Core;
using Core.Services;

namespace AnimalShelterTests
{
    [TestClass]
    public class AppointmentsTest
    {
        private AppointmentService _appointmentService;
        public AppointmentsTest()
        {
            _appointmentService = new AppointmentService();
        }

        [TestMethod]
        public void CorrectSavingAndDeleting()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            AnimalAppointment appointment = 
                        new AnimalAppointment(DateTime.Now, animal);
            Assert.IsNotNull(appointment);

            {
                _appointmentService.SaveAnimalAppointment(appointment);
                List<AnimalAppointment> appointments = 
                                _appointmentService.GetAnimalAppointments();
                Assert.IsTrue(appointments.Contains(appointment));
            }

            {
                _appointmentService.DeleteAnimalAppointment(appointment);
                List<AnimalAppointment> appointments = 
                            _appointmentService.GetAnimalAppointments();
                Assert.IsFalse(appointments.Contains(appointment));
            }
        }

        [TestMethod]
        public void GetByIdRetursValue()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            AnimalAppointment appointment = new AnimalAppointment(DateTime.Now, animal);
            _appointmentService.SaveAnimalAppointment(appointment);

            AnimalAppointment returnedAppointment = 
                        _appointmentService.GetAnimalAppointment(appointment.Id);

            Assert.AreEqual(appointment, returnedAppointment);
        }

        [TestMethod]
        public void GetByIdReturnsNull()
        {
            int id = -1;

            AnimalAppointment returnedAppointment = 
                        _appointmentService.GetAnimalAppointment(id);

            Assert.IsNull(returnedAppointment);
        }
    }
}
