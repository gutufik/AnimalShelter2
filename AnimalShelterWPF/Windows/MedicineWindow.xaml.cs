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
using System.Windows.Shapes;
using Core;
using Core.Services;

namespace AnimalShelterWPF.Windows
{
    /// <summary>
    /// Interaction logic for MedicineWindow.xaml
    /// </summary>
    public partial class MedicineWindow : Window
    {
        private MedicineService _medicineService;
        public Medicine Medicine { get; set; }
        public MedicineWindow(Medicine medicine)
        {
            InitializeComponent();
            _medicineService = new MedicineService();
            Medicine = medicine;
            DataContext = Medicine;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                _medicineService.SaveMedicine(Medicine);
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните название лекарства");
            }
        }
    }
}
