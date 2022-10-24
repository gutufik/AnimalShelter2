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
    /// Interaction logic for FoodListPage.xaml
    /// </summary>
    public partial class FoodListPage : Page
    {
        public List<Food> Foods { get; set; }
        private DataAccess dataAccess;

        public FoodListPage()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            Foods = dataAccess.GetFoods();

            DataAccess.RefreshListsEvent += RefreshList;

            DataContext = this;
        }

        private void RefreshList()
        {
            Foods = dataAccess.GetFoods();
            lvFoods.ItemsSource = Foods;

            lvFoods.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var food = (sender as Button).DataContext as Food;
            NavigationService.Navigate(new FoodPage(food));
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FoodPage(new Food()));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var food = (sender as Button).DataContext as Food;

            if (MessageBox.Show("Выбранный корм будет безвозватно удален.", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                dataAccess.DeleteFood(food);
                Foods = dataAccess.GetFoods();
                lvFoods.ItemsSource = Foods;

                lvFoods.Items.Refresh();
            }
        }
    }
}
