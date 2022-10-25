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
        public List<Manufacturer> Manufacturers { get; set; }
        public List<FoodType> FoodTypes { get; set; }
        public List<AnimalCategory> AnimalCategories { get; set; }

        private DataAccess dataAccess;

        public FoodListPage()
        {
            InitializeComponent();
            dataAccess = new DataAccess();

            Foods = dataAccess.GetFoods();
            FoodTypes = dataAccess.GetFoodTypes();
            Manufacturers = dataAccess.GetManufacturers();
            AnimalCategories = dataAccess.GetAnimalCategories();

            FoodTypes.Insert(0, new FoodType { Name = "Все" });
            Manufacturers.Insert(0, new Manufacturer { Name = "Все" });
            AnimalCategories.Insert(0, new AnimalCategory { Name = "Все" });


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
            var food = (sender as MenuItem).DataContext as Food;
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
            var food = (sender as MenuItem).DataContext as Food;

            if (MessageBox.Show("Выбранный корм будет безвозватно удален.", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                dataAccess.DeleteFood(food);
                Foods = dataAccess.GetFoods();
                lvFoods.ItemsSource = Foods;

                lvFoods.Items.Refresh();
            }
        }

        private void FiltersSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var manufacturer = cbManufacturer.SelectedItem as Manufacturer;
            var foodType = cbFoodType.SelectedItem as FoodType;
            var animalCategory = cbAnimalCategory.SelectedItem as AnimalCategory;

            var filteredFoods = Foods;

            if (manufacturer != null && manufacturer.Name != "Все")
                filteredFoods = filteredFoods.Where(x => x.Manufacturer == manufacturer).ToList();
            if(foodType != null && foodType.Name != "Все")
                filteredFoods = filteredFoods.Where(x => x.FoodType == foodType).ToList();
            if (animalCategory != null && animalCategory.Name != "Все")
                filteredFoods = filteredFoods.Where(x => x.AnimalCategory == animalCategory).ToList();

            if (!filteredFoods.Any())
            {
                tbEmptyList.Visibility = Visibility.Visible;
                lvFoods.Visibility = Visibility.Hidden;
            }
            else
            {
                tbEmptyList.Visibility = Visibility.Hidden;
                lvFoods.Visibility = Visibility.Visible;
            }

            lvFoods.ItemsSource = filteredFoods;
            lvFoods.Items.Refresh();
        }
    }
}
