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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var password = pbPassword.Password.ToString();

            App.User = DataAccess.GetUser(login, password);

            if (App.User != null)
            {
                NavigationService.Navigate(new Pages.IndexPage());

            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //App.User = new User();
            NavigationService.Navigate(new Pages.RegistrationPage());
        }
    }
}
