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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public User User { get; set; }

        public RegistrationPage()
        {
            InitializeComponent();
            User = new User() { Employee = new Employee() };

            DataContext = User;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != pbConfirmPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            User.Password = pbPassword.Password.ToString();
            DataAccess.SaveUser(User);
            App.User = DataAccess.GetUser(User.Login, User.Password);
            NavigationService.Navigate(new Pages.IndexPage());
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
