using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Services
{
    public class AppointmentService
    {
        private DataAccess _dataAccess;

        public AppointmentService()
        {
            _dataAccess = new DataAccess();
        }
        public List<AnimalAppointment> GetAnimalAppointments()
        {
            return _dataAccess.GetAnimalAppointments();
        }
        public List<AnimalAppointment> GetAnimalAppointments(Animal animal)
        {
            return _dataAccess.GetAnimalAppointments(animal);
        }
        public List<AnimalAppointment> GetAnimalAppointments(DateTime date)
        {
            return _dataAccess.GetAnimalAppointments(date);
        }
        public AnimalAppointment GetAnimalAppointment(int id)
        {
            return _dataAccess.GetAnimalAppointment(id);
        }
        public void SaveAnimalAppointment(AnimalAppointment appointment)
        {
            _dataAccess.SaveAnimalAppointment(appointment);
        }
        public List<AppointmentType> GetAppointmentTypes()
        {
            return _dataAccess.GetAppointmentTypes();
        }
        public void DeleteAnimalAppointment(AnimalAppointment appointment)
        {
            _dataAccess.DeleteAnimalAppointment(appointment);
        }
        public void UpdateAppointment(AnimalAppointment appointment)
        {
            _dataAccess.UpdateAppointment(appointment);
        }

    }
}
