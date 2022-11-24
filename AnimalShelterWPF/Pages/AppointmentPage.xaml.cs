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
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public List<Animal> Animals { get; set; }
        public AnimalAppointment Appointment { get; set; }
        public List<AppointmentType> Types { get; set; }
        public List<Medicine> Medicines { get; set; }

        private MedicineService _medicineService;
        private AppointmentService _appointmentService;
        private AnimalService _animalService;

        public AppointmentPage()
        {
            InitializeComponent();

            _medicineService = new MedicineService();
            _appointmentService = new AppointmentService();
            _animalService = new AnimalService();

            Appointment = new AnimalAppointment()
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay
            };
            Animals = _animalService.GetAnimals();
            Types = _appointmentService.GetAppointmentTypes();
            Medicines = _medicineService.GetMedicines();

            dpDate.DisplayDateStart = DateTime.Now;
            dpDate.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(30);

            DataContext = this;
        }
        public AppointmentPage(AnimalAppointment appointment)
        {
            InitializeComponent();

            _medicineService = new MedicineService();
            _appointmentService= new AppointmentService();
            _animalService = new AnimalService();

            Appointment = appointment;
            Animals = _animalService.GetAnimals();
            Types = _appointmentService.GetAppointmentTypes();
            Medicines = _medicineService.GetMedicines();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(30);

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Поля заполнены некорректно");
            try
            {
                if (Appointment.Date < DateTime.Now)
                {
                    stringBuilder.AppendLine("Нельзя изменять прошедшие назначения");
                    throw new Exception();
                }
                _appointmentService.SaveAnimalAppointment(Appointment);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(stringBuilder.ToString());
            }

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void cbMedicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var medicine = cbMedicines.SelectedItem as Medicine;
            if (Appointment.AppointmentMedicines.Where(m => m.Medicine.Id == medicine.Id).Count() == 0)
                Appointment.AppointmentMedicines.Add(new AppointmentMedicine { Medicine = medicine });

            lvMedicines.ItemsSource = Appointment.AppointmentMedicines;
            lvMedicines.Items.Refresh();
        }
    }
}
