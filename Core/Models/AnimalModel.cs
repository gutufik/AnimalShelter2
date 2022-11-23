using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Http;

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
            CapturePlace = "";
            Sign = "";
            ImageFile = null;
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
            CapturePlace = animal.CapturePlace;
            Sign = animal.Sign;
            CuratorId = animal.CuratorId;
        }

        public int Id { get; set; }
        [Required(ErrorMessage="У животного должна быть кличка"), MinLength(3)]
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Breed { get; set; }
        [Required(ErrorMessage = "Это поле обязательно"), MinLength(1)]
        public System.DateTime ArrivalDate { get; set; }
        public int StatusId { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Weight { get; set; }
        [Required(ErrorMessage ="Это поле обязательно"), MinLength(1)]
        public int Age { get; set; }
        public int GenderId { get; set; }
        public string Color { get; set; }
        [Required(ErrorMessage = "Это поле обязательно"), MinLength(1)]
        public string CapturePlace { get; set; }
        public string Sign { get; set; }
        public int CuratorId { get; set; }
        public byte[] Image { get; set; }
        public IFormFile ImageFile 
        {
            get;
            set;
        } 
        public bool IsDeleted { get; set; }
    }
}
