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
using Excel = Microsoft.Office.Interop.Excel;

namespace AnimalShelterWPF.Pages
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {

        public List<AnimalAppointment> Appointments { get; set; }
        public CalendarPage()
        {
            InitializeComponent();
            foreach (var appointment in DataAccess.GetAnimalAppointments())
            {
                appointmentCalendar.SelectedDates.Add(appointment.Date);
            }
            DataAccess.RefreshListsEvent += RefreshList;
            DataContext = this;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointments = DataAccess.GetAnimalAppointments(((DateTime)appointmentCalendar.SelectedDate).Date);

            foreach (var appintment in DataAccess.GetAnimalAppointments())
            {
                appointmentCalendar.SelectedDates.Add(appintment.Date);
            }
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
            Appointments = DataAccess.GetAnimalAppointments(((DateTime)appointmentCalendar.SelectedDate).Date);
            lvAppointments.ItemsSource = Appointments;
            lvAppointments.Items.Refresh();
        }
        public void ExportAppointments(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int rowIndex = 2;

            worksheet.Name = $"Назначения";
            
            worksheet.Cells[1][1] = "Дата";
            worksheet.Cells[2][1] = "Животное";
            worksheet.Cells[3][1] = "Тип назначения";

            for (int i = 0; i < Appointments.Count; i++)
            {
                worksheet.Cells[1][rowIndex] = Appointments[i].Date.ToShortDateString();
                worksheet.Cells[2][rowIndex] = Appointments[i].Animal.Name;
                worksheet.Cells[3][rowIndex] = Appointments[i].AppointmentType.Name;
                rowIndex++;
            }
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();

            application.Visible = true;

        }
    }
}
