﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core
{
    public partial class Animal
    {
        public Animal(string name, DateTime arrivalDate, string color, int age)
        {
            Name = name;
            ArrivalDate = arrivalDate;
            Color = color;
            Age = age;
        }

        public Animal(AnimalModel model)
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
            CapturePlace = model.CapturePlace;
            Sign = model.Sign;
            CuratorId = model.CuratorId;

            if(model.ImageFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    model.ImageFile.CopyTo(memoryStream);
                    Image = memoryStream.ToArray();
                }
            }
        }
    }
}
