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
    /// Interaction logic for AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public List<Animal> Animals { get; set; }
        private List<Employee> employees;
        public AnimalsPage()
        {
            InitializeComponent();

            DataAccess.RefreshListsEvent += RefreshList;

            Animals = DataAccess.GetAnimals();
            employees = DataAccess.GetEmployees();
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

            DataAccess.DeleteAnimal(animal);
            Animals = DataAccess.GetAnimals();
            lvAnimals.ItemsSource = Animals;

            lvAnimals.Items.Refresh();

        }
        private void RefreshList()
        {
            Animals = DataAccess.GetAnimals();
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

            for (int i = 0; i < employees.Count; i++)
            {
                worksheet.Cells[1][rowIndex] = employees[i].LastName;
                worksheet.Cells[2][rowIndex] = employees[i].FirstName;
                for (int j = 0; j < employees[i].Animals.Count; j++)
                {
                    worksheet.Cells[3][rowIndex] = employees[i].Animals.ToList()[j].Name;
                    rowIndex++;
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
    }
}

