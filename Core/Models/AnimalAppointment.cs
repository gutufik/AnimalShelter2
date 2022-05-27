using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core
{
    public partial class AnimalAppointment
    {
        public AnimalAppointment(DateTime date) : base()
        {
            //this.AppointmentMedicines = new HashSet<AppointmentMedicine>();
            Date = date;
            Time = date.TimeOfDay;
        }
        public AnimalAppointment(DateTime date, Animal animal) : base()
        {
            Date = date;
            Animal = animal;
        }

        public AnimalAppointment(AppointmentModel model)
        {
            Id = model.Id;
            Date = model.Date;
            Time = model.Time;
            AnimalId = model.AnimalId;
            TypeId = model.TypeId;
        }
    }
}
