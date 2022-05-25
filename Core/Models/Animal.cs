using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
