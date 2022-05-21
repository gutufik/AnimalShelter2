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
    }
}
