using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Core
{
    public class DataAccess
    {
        #region Events
        public delegate void RefreshTitleDelegate();
        public static event RefreshTitleDelegate RefreshTitleEvent;

        public delegate void RefreshListsDelegate();
        public static event RefreshListsDelegate RefreshListsEvent;
        #endregion

        #region Animal

        public List<Animal> GetAnimals()
        {
            return AnimalShelterEntities.GetContext().Animals.Where(a => !a.IsDeleted).ToList();
        }
        public Animal GetAnimal(int id)
        {
            return GetAnimals().FirstOrDefault(a => a.Id == id);
        }
        public void SaveAnimal(Animal animal)
        {
            if (animal.Id == 0)
                AnimalShelterEntities.GetContext().Animals.Add(animal);

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public void DeleteAnimal(Animal animal)
        {
            animal.IsDeleted = true;

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public List<AnimalType> GetAnimalTypes()
        { 
            return AnimalShelterEntities.GetContext().AnimalTypes.ToList();
        }
        public List<Status> GetAnimalStatuses()
        {
            return AnimalShelterEntities.GetContext().Status.ToList();
        }
        public List<Gender> GetGenders()
        {
            return AnimalShelterEntities.GetContext().Genders.ToList();
        }
        public void UpdateAnimal(Animal animal)
        {
            var baseAnimal = GetAnimal(animal.Id);

            baseAnimal.Name = animal.Name;
            baseAnimal.TypeId = animal.TypeId;
            baseAnimal.Breed = animal.Breed;
            baseAnimal.ArrivalDate = animal.ArrivalDate;
            baseAnimal.StatusId = animal.StatusId;
            baseAnimal.Height = animal.Height;
            baseAnimal.Weight = animal.Weight;
            baseAnimal.Age = animal.Age;
            baseAnimal.GenderId = animal.GenderId;
            baseAnimal.Color = animal.Color;
            baseAnimal.CapturePlace = animal.CapturePlace;
            baseAnimal.Sign = animal.Sign;
            baseAnimal.CuratorId = animal.CuratorId;

            SaveAnimal(baseAnimal);
        }

        #endregion

        #region Appointment

        public List<AnimalAppointment> GetAnimalAppointments()
        {
            return AnimalShelterEntities.GetContext().AnimalAppointments.Where(a => !a.IsDeleted).ToList();
        }
        public List<AnimalAppointment> GetAnimalAppointments(Animal animal)
        {
            return GetAnimalAppointments().Where(aa => aa.AnimalId == animal.Id).ToList();
        }
        public List<AnimalAppointment> GetAnimalAppointments(DateTime date)
        {
            return GetAnimalAppointments().Where(aa => aa.Date == date.Date).ToList();
        }
        public AnimalAppointment GetAnimalAppointment(int id)
        {
            return GetAnimalAppointments().FirstOrDefault(aa => aa.Id == id);
        }
        public void SaveAnimalAppointment(AnimalAppointment appointment)
        {
            if (GetAnimalAppointments().FirstOrDefault(a => a.Id == appointment.Id) == null)
                AnimalShelterEntities.GetContext().AnimalAppointments.Add(appointment);

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public List<AppointmentType> GetAppointmentTypes()
        {
            return AnimalShelterEntities.GetContext().AppointmentTypes.ToList();
        }
        public void DeleteAnimalAppointment(AnimalAppointment appointment)
        {
            appointment.IsDeleted = true;
            appointment.Animal.IsDeleted = true;
            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public void UpdateAppointment(AnimalAppointment appointment)
        {
            var baseAppointment = GetAnimalAppointment(appointment.Id);

            baseAppointment.Id = appointment.Id;
            baseAppointment.Date = appointment.Date;
            baseAppointment.Time = appointment.Time;
            baseAppointment.AnimalId = appointment.AnimalId;
            baseAppointment.TypeId = appointment.TypeId;

            SaveAnimalAppointment(baseAppointment);
        }

        #endregion

        #region User

        public User GetUser(string login, string password)
        {
            var user = GetUsers().FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
                RefreshTitleEvent?.Invoke();
            return user;
        }
        public User GetUser(int id)
        {
            return GetUsers().FirstOrDefault(u => u.Id == id);
        }
        public List<Employee> GetEmployees()
        {
            return AnimalShelterEntities.GetContext().Employees.ToList();
        }
        public void SaveUser(User user)
        {
            if (GetUsers().FirstOrDefault(u => u.Id == user.Id) == null)
                AnimalShelterEntities.GetContext().Users.Add(user);
            SaveEmployee(user.Employee);

            AnimalShelterEntities.GetContext().SaveChanges();
        }
        public void SaveEmployee(Employee employee)
        {
            if (GetEmployees().FirstOrDefault(e => e.Id == employee.Id) == null)
                AnimalShelterEntities.GetContext().Employees.Add(employee);

            AnimalShelterEntities.GetContext().SaveChanges();
        }
        public List<User> GetUsers()
        {
            return AnimalShelterEntities.GetContext().Users.ToList();
        }

        #endregion

        #region Medicine

        public List<Medicine> GetMedicines()
        {
            return AnimalShelterEntities.GetContext().Medicines.Where(m => !m.IsDeleted).ToList();
        }
        public void SaveMedicine(Medicine medicine)
        {
            if (GetMedicines().FirstOrDefault(m => m.Id == medicine.Id) == null
                && GetMedicines().Count(m => m.Name == medicine.Name) == 0)
                AnimalShelterEntities.GetContext().Medicines.Add(medicine);

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }
        public void DeleteMedicine(Medicine medicine)
        {
            medicine.IsDeleted = true;
            SaveMedicine(medicine);
            RefreshListsEvent?.Invoke();
        }

        #endregion

        #region Food

        public List<Food> GetFoods() => AnimalShelterEntities.GetContext().Foods.ToList();

        public List<AnimalFood> GetAnimalFoods() => AnimalShelterEntities.GetContext().AnimalFoods.ToList();

        public List<DietPlan> GetDietPlans() => AnimalShelterEntities.GetContext().DietPlans.ToList();

        public List<AnimalCategory> GetAnimalCategories() => AnimalShelterEntities.GetContext().AnimalCategories.ToList();

        public List<FoodType> GetFoodTypes() => AnimalShelterEntities.GetContext().FoodTypes.ToList();

        public List<Manufacturer> GetManufacturers() => AnimalShelterEntities.GetContext().Manufacturers.ToList();


        public void SaveFood(Food food)
        {
            if (!GetFoods().Contains(food))
                AnimalShelterEntities.GetContext().Foods.Add(food);

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        public void SaveDietPlan(DietPlan plan)
        {
            if (!GetDietPlans().Contains(plan))
                AnimalShelterEntities.GetContext().DietPlans.Add(plan);

            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        public void DeleteDietPlan(DietPlan diet)
        {
            AnimalShelterEntities.GetContext().DietPlans.Remove(diet);
            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }

        public void DeleteFood(Food food)
        {
            AnimalShelterEntities.GetContext().Foods.Remove(food);
            AnimalShelterEntities.GetContext().SaveChanges();
            RefreshListsEvent?.Invoke();
        }



        #endregion

        public static List<Role> GetRoles() => AnimalShelterEntities.GetContext().Roles.ToList();

        public static Role GetRole(int id) => GetRoles().FirstOrDefault(x => x.Id == id);
        
    }
}