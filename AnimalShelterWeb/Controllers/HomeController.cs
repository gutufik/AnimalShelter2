using AnimalShelterWeb.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserService userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            userService = new UserService();
        }

        public IActionResult Index()
        {
            if (Request.Cookies["Id"] != null)
            {
                var userId = int.Parse(Request.Cookies["Id"]);
                UserService.User = userService.GetUser(userId);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
