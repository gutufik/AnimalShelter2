using Microsoft.AspNetCore.Mvc;
using Core;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System;
using System.Linq;
using Fingers10.ExcelExport.ActionResults;
using ClosedXML.Excel;

namespace AnimalShelterWeb.Controllers
{
    public class AnimalController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var animals = DataAccess.GetAnimals();
            return View(animals);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            return View(animal);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Animal animal)
        {
            DataAccess.UpdateAnimal(animal);
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        { 
            DataAccess.SaveAnimal(animal);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var animal = DataAccess.GetAnimal(id);
            DataAccess.DeleteAnimal(animal);

            return Redirect("~/animal/");
        }
        public IActionResult Export()
        {
            var animals = DataAccess.GetAnimals();
            var employees = DataAccess.GetEmployees();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Животные");
                int currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Дата прибытия";
                worksheet.Cell(currentRow, 2).Value = "Кличка";
                worksheet.Cell(currentRow, 3).Value = "Вид";
                worksheet.Cell(currentRow, 4).Value = "Статус";
                foreach (var animal in animals)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = animal.ArrivalDate.ToShortDateString();
                    worksheet.Cell(currentRow, 2).Value = animal.Name;
                    worksheet.Cell(currentRow, 3).Value = animal.AnimalType.Name;
                    worksheet.Cell(currentRow, 4).Value = animal.Status.Name;
                }

                worksheet = workbook.Worksheets.Add("Сотрудники");
                currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Фамилия";
                worksheet.Cell(currentRow, 2).Value = "Имя";
                worksheet.Cell(currentRow, 3).Value = "Животные";

                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employee.LastName;
                    worksheet.Cell(currentRow, 2).Value = employee.FirstName;
                    foreach (var animal in employee.Animals)
                    {
                        if (!animal.IsDeleted)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 3).Value = animal.Name;
                        }
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Export.xlsx");
                }
            }
        }
    }
}
