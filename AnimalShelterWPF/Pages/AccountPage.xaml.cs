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
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public User User { get; set; }

        private UserService _userService;
        public AccountPage()
        {
            InitializeComponent();
            _userService = new UserService();
            User = App.User;
            if (User.Employee.Role.Name != "Админ")
                btnAdmin.Visibility = Visibility.Collapsed;
            DataContext = User;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _userService.SaveUser(User);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.User = null;
            Properties.Settings.Default.Reset();

            NavigationService.Navigate(new LoginPage());
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }
    }
}
