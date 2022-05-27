using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Models
{
    public class AnimalModel
    {
        public AnimalModel()
        {
            Id = 0;
            Name = "";
            TypeId = 0;
            Breed = "";
            ArrivalDate = new DateTime();
            StatusId = 0;
            Height = 0;
            Weight = 0;
            Age = 0;
            GenderId = 0;
            Color = "";
            Character = "";
            CapturePlace = "";
            Sign = "";
            CuratorId = 0;
        }

        public AnimalModel(Animal animal)
        { 
            Id = animal.Id;
            Name = animal.Name;
            TypeId = animal.TypeId;
            Breed = animal.Breed;
            ArrivalDate = animal.ArrivalDate;
            StatusId = animal.StatusId;
            Height = animal.Height;
            Weight = animal.Weight;
            Age = animal.Age;
            GenderId = animal.GenderId;
            Color = animal.Color;
            Character = animal.Character;
            CapturePlace = animal.CapturePlace;
            Sign = animal.Sign;
            CuratorId = animal.CuratorId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> TypeId { get; set; }
        public string Breed { get; set; }
        public System.DateTime ArrivalDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string Color { get; set; }
        public string Character { get; set; }
        public string CapturePlace { get; set; }
        public string Sign { get; set; }
        public Nullable<int> CuratorId { get; set; }
    }
}
