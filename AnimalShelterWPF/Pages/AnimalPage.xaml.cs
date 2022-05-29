using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using Microsoft.Win32;

namespace AnimalShelterWPF.Pages
{
    /// <summary>
    /// Interaction logic for AnimalPage.xaml
    /// </summary>
    public partial class AnimalPage : Page
    {
        public Animal Animal { get; set; }
        public List<AnimalType> Types { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Status> Statuses { get; set; }
        public List<Employee> Curators { get; set; }

        public AnimalPage()
        {
            InitializeComponent();
            Animal = new Animal();
            Statuses = DataAccess.GetAnimalStatuses();
            Types = DataAccess.GetAnimalTypes();
            Genders = DataAccess.GetGenders();
            Curators = DataAccess.GetEmployees();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now;

            DataContext = this;
        }
        public AnimalPage(Animal animal)
        {
            InitializeComponent();
            Animal = animal;
            Statuses = DataAccess.GetAnimalStatuses();
            Types = DataAccess.GetAnimalTypes();
            Genders = DataAccess.GetGenders();
            Curators = DataAccess.GetEmployees();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now;

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            //Нужна нормальная валидация
            try
            {
                if (Animal.ArrivalDate > DateTime.Now)
                    throw new Exception();
                DataAccess.SaveAnimal(Animal);
                NavigationService.GoBack();

            }
            catch
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var photo = File.ReadAllBytes(fileDialog.FileName);

                Animal.Image = photo;
                animalImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
