using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
