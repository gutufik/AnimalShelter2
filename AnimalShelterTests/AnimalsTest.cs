using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Core;

namespace AnimalShelterTests
{
    [TestClass]
    public class AnimalsTest
    {
        [TestMethod]
        public void CorrectSavingAndDeleting()
        { 
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            Assert.IsNotNull(animal);
            
            {
                DataAccess.SaveAnimal(animal);
                List<Animal> animals = DataAccess.GetAnimals();
                Assert.IsTrue(animals.Contains(animal));
            }

            {
                DataAccess.DeleteAnimal(animal);
                List<Animal> animals = DataAccess.GetAnimals();
                Assert.IsFalse(animals.Contains(animal));
            }
        }

        [TestMethod]
        public void GetByIdRetursValue()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            DataAccess.SaveAnimal(animal);

            Animal returnedAnimal = DataAccess.GetAnimal(animal.Id);

            Assert.AreEqual(animal, returnedAnimal);
        }

        [TestMethod]
        public void GetByIdReturnsNull()
        {
            int id = -1;

            Animal returnedAnimal = DataAccess.GetAnimal(id);

            Assert.IsNull(returnedAnimal);
        }
    }
}
