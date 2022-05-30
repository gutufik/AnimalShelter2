using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using ClosedXML.Excel;
using System.IO;

namespace AnimalShelterWeb.Controllers
{
    public class CalendarController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var appointments = DataAccess.GetAnimalAppointments();
            return View(appointments);
        }
        public IActionResult Delete(int id)
        {
            var appointment = DataAccess.GetAnimalAppointment(id);
            DataAccess.DeleteAnimalAppointment(appointment);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        { 
            return View();
        }

        public IActionResult Export()
        {
            var appointments = DataAccess.GetAnimalAppointments();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Животные");
                int currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Дата";
                worksheet.Cell(currentRow, 2).Value = "Животное";
                worksheet.Cell(currentRow, 3).Value = "Тип назначения";

                foreach (var appointment in appointments)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = appointment.Date.ToShortDateString();
                    worksheet.Cell(currentRow, 2).Value = appointment.Animal.Name;
                    worksheet.Cell(currentRow, 3).Value = appointment.AppointmentType.Name;
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
