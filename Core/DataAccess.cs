using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataAccess
    {
        #region Animal

        public static List<Animal> GetAnimals()
        {
            return AnimalShelterEntities.GetContext().Animals.ToList();
        }

        public static Animal GetAnimal(int id)
        {
            return GetAnimals().FirstOrDefault(a => a.Id == id);
        }

        public static void SaveAnimal(Animal animal)
        {
            if (GetAnimals().FirstOrDefault(a => a.Id == animal.Id) == null)
                AnimalShelterEntities.GetContext().Animals.Add(animal);

            AnimalShelterEntities.GetContext().SaveChanges();
        }

        public static void DeleteAnimal(Animal animal)
        {
            //AnimalShelterEntities.GetContext().Animals.Remove(animal);

            //AnimalShelterEntities.GetContext().SaveChanges();
        }
        #endregion 

        public static List<AnimalType> GetAnimalTypes()
        { 
            return AnimalShelterEntities.GetContext().AnimalTypes.ToList();
        }
        public static List<AnimalAppointment> GetAnimalAppointments()
        {
            return AnimalShelterEntities.GetContext().AnimalAppointments.ToList();
        }
        public static List<AnimalAppointment> GetAnimalAppointments(Animal animal)
        {
            return GetAnimalAppointments().Where(aa => aa.AnimalId == animal.Id).ToList();
        }

        public static List<Status> GetAnimalStatuses()
        {
            return AnimalShelterEntities.GetContext().Status.ToList();
        }

        public static User GetUser(string login, string password)
        {
            return AnimalShelterEntities.GetContext().Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public static List<Employee> GetEmployees()
        {
            return AnimalShelterEntities.GetContext().Employees.ToList();
        }
        public static void SaveAnimalAppointment(AnimalAppointment appointment)
        {
            if (GetAnimalAppointments().FirstOrDefault(a => a.Id == appointment.Id) == null)
                AnimalShelterEntities.GetContext().AnimalAppointments.Add(appointment);

            AnimalShelterEntities.GetContext().SaveChanges();
        }
        public static List<Medicine> GetMedicines()
        {
            return AnimalShelterEntities.GetContext().Medicines.ToList();
        }

    }
}
