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
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        public List<Animal> Animals { get; set; }
        public AnimalAppointment Appointment { get; set; }
        public List<AppointmentType> Types { get; set; }
        public AppointmentPage()
        {
            InitializeComponent();

            Appointment = new AnimalAppointment()
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay
            };
            Animals = DataAccess.GetAnimals();
            Types = DataAccess.GetAppointmentTypes();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(30);

            DataContext = this;
        }
        public AppointmentPage(AnimalAppointment appointment)
        {
            InitializeComponent();

            Appointment = appointment;
            Animals = DataAccess.GetAnimals();
            Types = DataAccess.GetAppointmentTypes();

            dpDate.DisplayDateStart = DateTime.Now - TimeSpan.FromDays(30);
            dpDate.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(30);

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Appointment.Date > DateTime.Now)
                    throw new Exception();
                Appointment.Time = ((DateTime)tpAppointmentTime.SelectedTime).TimeOfDay;
                DataAccess.SaveAnimalAppointment(Appointment);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
