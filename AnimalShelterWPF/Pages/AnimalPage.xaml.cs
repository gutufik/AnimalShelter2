using System;
using System.Collections.Generic;
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
        public List<Employee> Curators { get; set; }

        public AnimalPage()
        {
            InitializeComponent();
            Animal = new Animal();
            Types = DataAccess.GetAnimalTypes();
            Genders = DataAccess.GetGenders();
            Curators = DataAccess.GetEmployees();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now;

            cbTypes.ItemsSource = Types;
            cbGenders.ItemsSource = Genders;
            cbCurator.ItemsSource = Curators;
            DataContext = Animal;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
