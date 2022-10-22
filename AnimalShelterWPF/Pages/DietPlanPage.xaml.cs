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
    /// Interaction logic for DietPlanPage.xaml
    /// </summary>
    public partial class DietPlanPage : Page
    {
        public DietPlan DietPlan { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Food> Foods { get; set; }


        private DataAccess dataAccess;
        public DietPlanPage(DietPlan dietPlan)
        {
            InitializeComponent();
            DietPlan = dietPlan;
            if (DietPlan.AnimalFood == null)
                DietPlan.AnimalFood = new AnimalFood();

            dataAccess = new DataAccess();
            Animals = dataAccess.GetAnimals();
            Foods = dataAccess.GetFoods();

            dpDate.SelectedDate = dietPlan.Time == null ? DateTime.Today.Date: ((DateTime)dietPlan.Time).Date;
            tpTime.SelectedTime = dietPlan.Time == null ? DateTime.Now : ((DateTime)dietPlan.Time);

            DataContext = this;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.SaveDietPlan(DietPlan);
            NavigationService.GoBack();
        }

        private void cbAnimal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t =  cbAnimal.SelectedItem as Animal;
        }
    }
}
