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
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public User User { get; set; }
        public AccountPage()
        {
            InitializeComponent();
            User = App.User;
            DataContext = User;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveUser(User);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.User = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
