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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        public UserService userService { get; set; }
        public AdminPage()
        {
            userService = new UserService();
            InitializeComponent();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            Users = userService.GetUsers();
            Users.Remove(App.User);
            Roles = userService.GetRoles();
            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Users = userService.GetUsers();
            lvUsers.ItemsSource = Users;
            lvUsers.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as User;
            userService.SaveUser(user);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as User;
            if (MessageBox.Show("Выбранный пользователь будет безвозватно удален.", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                userService.DeleteUser(user);
            }

        }
    }
}
