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

        public delegate void RefreshListsDelegate();

        public static event RefreshListsDelegate RefreshListsEvent;

        #region Animal

        public static List<Animal> GetAnimals()
        {
            return AnimalShelterEntities.GetContext().Animals.Where(a => !a.IsDeleted).ToList();
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
            RefreshListsEvent?.Invoke();
        }

        public static void DeleteAnimal(Animal animal)
        {
            animal.IsDeleted = true;

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public static List<AnimalType> GetAnimalTypes()
        { 
            return AnimalShelterEntities.GetContext().AnimalTypes.ToList();
        }
        #endregion 

        public static List<AnimalAppointment> GetAnimalAppointments()
        {
            return AnimalShelterEntities.GetContext().AnimalAppointments.Where(a => !a.IsDeleted).ToList();
        }
        public static List<AnimalAppointment> GetAnimalAppointments(Animal animal)
        {
            return GetAnimalAppointments().Where(aa => aa.AnimalId == animal.Id).ToList();
        }

        public static List<AnimalAppointment> GetAnimalAppointments(DateTime date)
        {
            return GetAnimalAppointments().Where(aa => aa.Date == date.Date).ToList();
        }
        public static AnimalAppointment GetAnimalAppointment(int id)
        {
            return GetAnimalAppointments().FirstOrDefault(aa => aa.Id == id);
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
            RefreshListsEvent?.Invoke();
        }
        public static List<Medicine> GetMedicines()
        {
            return AnimalShelterEntities.GetContext().Medicines.Where(m => !m.IsDeleted).ToList();
        }
        public static void SaveMedicine(Medicine medicine)
        {
            if (GetMedicines().FirstOrDefault(m => m.Id == medicine.Id) == null)
                AnimalShelterEntities.GetContext().Medicines.Add(medicine);

            AnimalShelterEntities.GetContext().SaveChanges();
        }
        public static void DeleteMedicine(Medicine medicine)
        {
            medicine.IsDeleted = true;
            SaveMedicine(medicine);
            RefreshListsEvent?.Invoke();
        }

        public static void SaveUser(User user)
        {
            if (GetUsers().FirstOrDefault(u => u.Id == user.Id) == null)
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
        public static List<AppointmentType> GetAppointmentTypes()
        { 
            return AnimalShelterEntities.GetContext().AppointmentTypes.ToList();
        }
        public static void DeleteAnimalAppointment(AnimalAppointment appointment)
        {
            appointment.IsDeleted = true;
            appointment.Animal.IsDeleted = true;
            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
    }
}
