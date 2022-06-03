using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Services
{
    public class AnimalService
    {
        private DataAccess _dataAccess;
        public AnimalService()
        {
            _dataAccess = new DataAccess();
        }
        public List<Animal> GetAnimals()
        {
            return _dataAccess.GetAnimals();
        }
        public Animal GetAnimal(int id)
        { 
            return _dataAccess.GetAnimal(id); ;
        }
        public void SaveAnimal(Animal animal)
        {
            _dataAccess.SaveAnimal(animal);
        }
        public void DeleteAnimal(Animal animal)
        {
            _dataAccess.DeleteAnimal(animal);
        }
        public List<AnimalType> GetAnimalTypes()
        {
            return _dataAccess.GetAnimalTypes();
        }
        public List<Status> GetAnimalStatuses()
        { 
            return _dataAccess.GetAnimalStatuses();
        }
        public List<Gender> GetGenders()
        { 
            return _dataAccess.GetGenders();
        }
        public void UpdateAnimal(Animal animal)
        {
            _dataAccess.UpdateAnimal(animal);
        }
    }
}
