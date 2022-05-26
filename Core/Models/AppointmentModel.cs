using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppointmentModel
    {
        public AppointmentModel(AnimalAppointment appointment)
        { 
            Id = appointment.Id;
            Date = appointment.Date;
            Time = appointment.Time;
            AnimalId = appointment.AnimalId;
            TypeId = appointment.TypeId;
        }
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public int AnimalId { get; set; }
        public Nullable<int> TypeId { get; set; }
    }
}
