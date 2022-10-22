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
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        private DataAccess dataAccess;
        public Food Food { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<AnimalType> AnimalTypes { get; set; }
        public List<AnimalCategory> AnimalCategories { get; set; }
        public List<FoodType> FoodTypes { get; set; }

        public FoodPage(Food food)
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            Food = food;
            Manufacturers = dataAccess.GetManufacturers();
            AnimalTypes = dataAccess.GetAnimalTypes();
            AnimalCategories = dataAccess.GetAnimalCategories();
            FoodTypes = dataAccess.GetFoodTypes();

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.SaveFood(Food);
            NavigationService.GoBack();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (fileDialog.ShowDialog().Value)
            {
                var photo = File.ReadAllBytes(fileDialog.FileName);
                if (photo.Length > 1024 * 150)  //Размер фотографии не должен превышать 150 Кбайт
                {
                    MessageBox.Show("Размер фотографии не должен превышать 150 КБ", "Ошибка");
                    return;
                }
                Food.Image = photo;
                FoodImage.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
