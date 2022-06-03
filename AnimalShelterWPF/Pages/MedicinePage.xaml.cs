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
using Core.Services;

namespace AnimalShelterWPF.Pages
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public Medicine Medicine { get; set; }
        private MedicineService _medicineService;
        public MedicinePage()
        {
            InitializeComponent();
            Medicine = new Medicine();
            _medicineService = new MedicineService();

            DataContext = Medicine;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _medicineService.SaveMedicine(Medicine);
            NavigationService.GoBack();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
