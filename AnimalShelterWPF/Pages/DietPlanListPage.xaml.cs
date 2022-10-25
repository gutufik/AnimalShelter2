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
        public List<Animal> Animals { get; set; }

        private DataAccess dataAccess;

        public DietPlanListPage()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            DietPlans = dataAccess.GetDietPlans();
            Animals = dataAccess.GetAnimals();
            Animals.Insert(0, new Animal { Name = "Все" });
            DataAccess.RefreshListsEvent += RefreshList;

            DataContext = this;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dietPlan = (sender as MenuItem).DataContext as DietPlan;

            NavigationService.Navigate(new DietPlanPage(dietPlan));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var dietPlan = (sender as MenuItem).DataContext as DietPlan;
            if (MessageBox.Show("Выбранный рацион будет безвозватно удален.", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                dataAccess.DeleteDietPlan(dietPlan);
                DietPlans = dataAccess.GetDietPlans();
                lvDietPlans.ItemsSource = DietPlans;

                lvDietPlans.Items.Refresh();
            }
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
            
            HideList();
        }

        private void btnAddDiet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DietPlanPage(new DietPlan()));
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnResetDates_Click(object sender, RoutedEventArgs e)
        {
            DietPlanCalendar.SelectedDates.Clear();

        }

        private void FiltersSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dates = DietPlanCalendar.SelectedDates.ToList();
            var filteredDietPlans = DietPlans;

            if (dates.Count != 0)
            {
                var firtDate = dates.First();
                var lastDate = dates.Last();

                filteredDietPlans = filteredDietPlans.FindAll(x => firtDate <= x.Time.Value.Date && x.Time.Value.Date <= lastDate);
            }

            var animal = cbAnimal.SelectedItem as Animal;
            if (animal != null && animal.Name != "Все")
                filteredDietPlans = filteredDietPlans.FindAll(x => x.AnimalFood.Animal == animal);

            lvDietPlans.ItemsSource = filteredDietPlans;
            lvDietPlans.Items.Refresh();
            HideList();
        }

        public void HideList()
        {
            if (lvDietPlans.Items.Count > 0)
            {
                lvDietPlans.Visibility = Visibility.Visible;
                tbEmptyList.Visibility = Visibility.Hidden;
            }
            else
            {
                lvDietPlans.Visibility = Visibility.Hidden;
                tbEmptyList.Visibility = Visibility.Visible;
            }
        }
    }
}
