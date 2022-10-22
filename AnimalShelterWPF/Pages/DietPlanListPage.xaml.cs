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
    /// Interaction logic for DietPlanListPage.xaml
    /// </summary>
    public partial class DietPlanListPage : Page
    {
        public List<DietPlan> DietPlans { get; set; }

        private DataAccess dataAccess;

        public DietPlanListPage()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            DietPlans = dataAccess.GetDietPlans();
            DataAccess.RefreshListsEvent += RefreshList;

            DataContext = this;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dietPlan = (sender as Button).DataContext as DietPlan;

            NavigationService.Navigate(new DietPlanPage(dietPlan));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var dietPlan = (sender as Button).DataContext as DietPlan;

            //_animalService.DeleteAnimal(animal);
            //Animals = _animalService.GetAnimals();
            //lvAnimals.ItemsSource = Animals;

            //lvAnimals.Items.Refresh();
        }

        private void RefreshList()
        {
            DietPlans = dataAccess.GetDietPlans();
            lvDietPlans.ItemsSource = DietPlans;

            lvDietPlans.Items.Refresh();
        }

        private void btnFoods_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FoodListPage());
        }

        private void DietPlanCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddDiet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DietPlanPage(new DietPlan()));
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
