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
    /// Interaction logic for AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public List<Animal> Animals { get; set; }
        private List<Employee> _employees;
        private UserService _userService;
        private AnimalService _animalService;
        public AnimalsPage()
        {
            InitializeComponent();
            _userService = new UserService();
            _animalService = new AnimalService();

            DataAccess.RefreshListsEvent += RefreshList;

            Animals = _animalService.GetAnimals();
            _employees = _userService.GetEmployees();
            DataContext = this;
        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AnimalPage());
        }

        private void btnAddAppintment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AppointmentPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;
            var animal = senderButton.DataContext as Animal;

            _animalService.DeleteAnimal(animal);
            Animals = _animalService.GetAnimals();
            lvAnimals.ItemsSource = Animals;

            lvAnimals.Items.Refresh();

        }
        private void RefreshList()
        {
            Animals = _animalService.GetAnimals();
            lvAnimals.ItemsSource = Animals;

            lvAnimals.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var animal = (sender as Button).DataContext as Animal;

            NavigationService.Navigate(new AnimalPage(animal));
        }
        public void Export(object sender, RoutedEventArgs e)
        {
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            int rowIndex = 2;

            worksheet.Name = $"Сотрудники";
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();
            worksheet.Cells[1][1] = "Фамилия";
            worksheet.Cells[2][1] = "Имя";
            worksheet.Cells[3][1] = "Животные";

            for (int i = 0; i < _employees.Count; i++)
            {
                worksheet.Cells[1][rowIndex] = _employees[i].LastName;
                worksheet.Cells[2][rowIndex] = _employees[i].FirstName;
                rowIndex++;
                foreach (var animal in _employees[i].Animals)
                {
                    if (!animal.IsDeleted)
                    {
                        worksheet.Cells[3][rowIndex] = animal.Name;
                        rowIndex++;
                    }
                }
            }
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();

            worksheet = application.Worksheets.Add();

            worksheet.Name = $"Животные";
            
            worksheet.Cells[1][1] = "Дата прибытия";
            worksheet.Cells[2][1] = "Кличка";
            worksheet.Cells[3][1] = "Вид";
            worksheet.Cells[4][1] = "Статус";
            rowIndex = 2;
            for (int i = 0; i < Animals.Count; i++)
            {
                worksheet.Cells[1][rowIndex] = Animals[i].ArrivalDate.ToShortDateString();
                worksheet.Cells[2][rowIndex] = Animals[i].Name;
                worksheet.Cells[3][rowIndex] = Animals[i].AnimalType.Name;
                worksheet.Cells[4][rowIndex] = Animals[i].Status.Name;
                rowIndex++;
            }
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();
            application.Visible = true;
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DietPlanListPage());
        }
    }
}

