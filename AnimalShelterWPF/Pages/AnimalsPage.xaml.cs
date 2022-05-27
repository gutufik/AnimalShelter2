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
    /// Interaction logic for AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public List<Animal> Animals { get; set; }
        public AnimalsPage()
        {
            InitializeComponent();

            DataAccess.RefreshListsEvent += RefreshList;

            Animals = DataAccess.GetAnimals();
            DataContext = this;
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AnimalPage());
        }

        private void btnAddAppintment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AppointmentPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;
            var animal = senderButton.DataContext as Animal;

            DataAccess.DeleteAnimal(animal);
            Animals = DataAccess.GetAnimals();
            lvAnimals.ItemsSource = Animals;

            lvAnimals.Items.Refresh();

        }
        private void RefreshList()
        {
            Animals = DataAccess.GetAnimals();
            lvAnimals.ItemsSource = Animals;

            lvAnimals.Items.Refresh();
        }

        private void lvAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var animal = lvAnimals.SelectedItem as Animal;
            NavigationService.Navigate(new AnimalPage(animal));
        }
    }
}
