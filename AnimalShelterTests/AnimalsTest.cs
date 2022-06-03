using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Core;
using Core.Services;

namespace AnimalShelterTests
{
    [TestClass]
    public class AnimalsTest
    {
        private AnimalService _animalService;

        public AnimalsTest()
        {
            _animalService = new AnimalService();
        }

        [TestMethod]
        public void CorrectSavingAndDeleting()
        { 
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            Assert.IsNotNull(animal);
            
            {
                _animalService.SaveAnimal(animal);
                List<Animal> animals = _animalService.GetAnimals();
                Assert.IsTrue(animals.Contains(animal));
            }

            {
                _animalService.DeleteAnimal(animal);
                List<Animal> animals = _animalService.GetAnimals();
                Assert.IsFalse(animals.Contains(animal));
            }
        }

        [TestMethod]
        public void GetByIdRetursValue()
        {
            Animal animal = new Animal("Васька", DateTime.Now, "Рыжий", 5);
            _animalService.SaveAnimal(animal);

            Animal returnedAnimal = _animalService.GetAnimal(animal.Id);

            Assert.AreEqual(animal, returnedAnimal);
        }

        [TestMethod]
        public void GetByIdReturnsNull()
        {
            int id = -1;

            Animal returnedAnimal = _animalService.GetAnimal(id);

            Assert.IsNull(returnedAnimal);
        }
    }
}
