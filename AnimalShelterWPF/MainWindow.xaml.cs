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

namespace AnimalShelterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Page> pages;

        public MainWindow()
        {
            pages = new Dictionary<string, Page> 
            {
                {"Главная", new Pages.IndexPage()},
                {"Животные", new Pages.AnimalsPage()},
                {"Календарь", new Pages.CalendarPage()},
                {"Медикаменты", new Pages.MedicinesPage()},
                {"Вход", new Pages.LoginPage()},
            };

            InitializeComponent();
            MainFrame.NavigationService.Navigate(new Pages.LoginPage());
        }

        private void LabelMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var page = (sender as Label).Content.ToString();
            if (App.User != null)
                MainFrame.NavigationService.Navigate(pages[page]);
            else
                MainFrame.NavigationService.Navigate(new Pages.LoginPage());
        }

        private void lblAnimals_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.AnimalsPage());
        }

        private void lblCalendar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.CalendarPage());
        }

        private void lblMedicines_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.MedicinesPage());
        }

        private void lblLogin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.LoginPage());
        }
    }
}
