using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core
{
    public partial class Animal
    {
        public Animal(string name, DateTime arrivalDate, string color, int age) : base()
        {
            Name = name;
            ArrivalDate = arrivalDate;
            Color = color;
            Age = age;
        }
        public Animal()
        {
            ArrivalDate = DateTime.Today;

            this.AnimalAppointments = new HashSet<AnimalAppointment>();
            this.AnimalComments = new HashSet<AnimalComment>();
        }

        public Animal(AnimalModel model) : base()
        {
            Id = model.Id;
            Name = model.Name;
            TypeId = model.TypeId;
            Breed = model.Breed;
            ArrivalDate = model.ArrivalDate;
            StatusId = model.StatusId;
            Height = model.Height;
            Weight = model.Weight;
            Age = model.Age;
            GenderId = model.GenderId;
            Color = model.Color;
            Character = model.Character;
            CapturePlace = model.CapturePlace;
            Sign = model.Sign;
            CuratorId = model.CuratorId;
        }
    }
}
