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
using AnimalShelterWPF.Pages;

namespace AnimalShelterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Type> pages;

        public MainWindow()
        {
            pages = new Dictionary<string, Type> 
            {
                {"Главная", typeof(IndexPage)},
                {"Животные", typeof(AnimalsPage)},
                {"Календарь", typeof(CalendarPage)},
                {"Медикаменты", typeof(MedicinesPage)},
                {"Вход", typeof(LoginPage)},
                {"Аккаунт", typeof(AccountPage)},
            };

            InitializeComponent();

            DataAccess.RefreshTitleEvent += RefreshUserPageTitle;
            MainFrame.NavigationService.Navigate(new Pages.LoginPage());
        }

        private void TitleClick(object sender, RoutedEventArgs e)
        {
            var page = (sender as Button).Content.ToString();
            if (App.User != null)
                MainFrame.NavigationService.Navigate(Activator.CreateInstance(pages[page]));
            else
                MessageBox.Show("Для перехода по страницам нужно авторизоваться");
        }

        public void RefreshUserPageTitle()
        {
            btnLogin.Content = "Аккаунт";
        }
    }
}
