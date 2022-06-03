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
using Excel = Microsoft.Office.Interop.Excel;

namespace AnimalShelterWPF.Pages
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {

        public List<AnimalAppointment> Appointments { get; set; }
        private AppointmentService _appointmentService;

        public CalendarPage()
        {
            InitializeComponent();
            _appointmentService = new AppointmentService();

            SetDates();
            DataAccess.RefreshListsEvent += RefreshList;
            DataContext = this;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointments = _appointmentService.GetAnimalAppointments(
                ((DateTime)appointmentCalendar.SelectedDate).Date);

            SetDates();
            if (Appointments.Count != 0)
            {
                lvAppointments.ItemsSource = Appointments;
                lvAppointments.Items.Refresh();
                lvAppointments.Visibility = Visibility.Visible;
                spNoAppointments.Visibility = Visibility.Hidden;
            }
            else
            {
                lvAppointments.Visibility = Visibility.Hidden;
                spNoAppointments.Visibility = Visibility.Visible;
            }
        }

        private void lvAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var appointment = (sender as ListView).SelectedItem as AnimalAppointment;

            if (appointment != null)
            {
                NavigationService.Navigate(new AppointmentPage(appointment));
            }
        }

        private void btnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            var appointment = new AnimalAppointment((DateTime)appointmentCalendar.SelectedDate);
            NavigationService.Navigate(new AppointmentPage(appointment));
        }
        public void RefreshList()
        {
            Appointments = _appointmentService.GetAnimalAppointments(
                ((DateTime)appointmentCalendar.SelectedDate).Date);
            lvAppointments.ItemsSource = Appointments;
            lvAppointments.Items.Refresh();
        }
        public void ExportAppointments(object sender, RoutedEventArgs e)
        {
            var appointments = Appointments.Where(x => !x.Animal.IsDeleted).ToList();

            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int rowIndex = 2;

            worksheet.Name = $"Назначения";
            
            worksheet.Cells[1][1] = "Дата";
            worksheet.Cells[2][1] = "Животное";
            worksheet.Cells[3][1] = "Тип назначения";

            for (int i = 0; i < appointments.Count; i++)
            {
                worksheet.Cells[1][rowIndex] = appointments[i].Date.ToShortDateString();
                worksheet.Cells[2][rowIndex] = appointments[i].Animal.Name;
                worksheet.Cells[3][rowIndex] = appointments[i].AppointmentType.Name;
                rowIndex++;
            }
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();

            application.Visible = true;

        }
        private void SetDates()
        {
            foreach (var appointment in _appointmentService.GetAnimalAppointments())
            {
                appointmentCalendar.SelectedDates.Add(appointment.Date);
            }
        }
    }
}
