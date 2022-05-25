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
    /// Interaction logic for MedicinesPage.xaml
    /// </summary>
    public partial class MedicinesPage : Page
    { 
        public List<Medicine> Medicines { get; set; }
        public MedicinesPage()
        {
            InitializeComponent();
            Medicines = DataAccess.GetMedicines();
            if (Medicines.Count == 0)
                lblEmpty.Visibility = Visibility.Visible;

            DataContext = Medicines;
            DataAccess.RefreshListsEvent += RefreshList;
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedicinePage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;
            var medicine = senderButton.DataContext as Medicine;

            DataAccess.DeleteMedicine(medicine);
            
        }
        private void RefreshList()
        {
            Medicines = DataAccess.GetMedicines();
            lvMedicines.ItemsSource = Medicines;

            lvMedicines.Items.Refresh();
        }
    }
}
