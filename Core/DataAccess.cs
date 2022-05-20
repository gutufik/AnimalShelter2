using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataAccess
    {
        public delegate void RefreshTitleDelegate();

        public static event RefreshTitleDelegate RefreshTitleEvent;

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
            AnimalShelterEntities.GetContext().Animals.Remove(animal);

            AnimalShelterEntities.GetContext().SaveChanges();
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
            var user = GetUsers().FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
                RefreshTitleEvent?.Invoke();
            return user;
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
        public static void SaveMedicine(Medicine medicine)
        {
            if (GetMedicines().FirstOrDefault(m => m.Id == medicine.Id) == null)
                AnimalShelterEntities.GetContext().Medicines.Add(medicine);

            AnimalShelterEntities.GetContext().SaveChanges();
        }

        public static void RegisterUser(User user)
        {
            AnimalShelterEntities.GetContext().Users.Add(user);

            AnimalShelterEntities.GetContext().SaveChanges();
        }

        public static List<User> GetUsers()
        {
            return AnimalShelterEntities.GetContext().Users.ToList();
        }
        public static List<Gender> GetGenders()
        {
            return AnimalShelterEntities.GetContext().Genders.ToList();
        }

    }
}
