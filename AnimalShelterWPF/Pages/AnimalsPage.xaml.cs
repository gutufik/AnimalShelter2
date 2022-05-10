﻿using System;
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

            Animals = DataAcccess.GetAnimals();
            DataContext = this;
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AnimalPage());
        }
    }
}
