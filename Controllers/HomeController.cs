using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UmbaniApiTest.Entities;
using UmbaniApiTest.Models;
using UmbaniApiTest.Services;
using UmbaniApiTest.ViewModels;

namespace UmbaniApiTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetMeasurementData _getMeasurement;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IGetMeasurementData getMeasurement, ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._getMeasurement = getMeasurement;
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            SeedData.Seed(this._dbContext);
            List<Item> model = new List<Item> { new Models.Measurement { Temperature = 23.4 , Humidity = 50 , Weight = 10 , Depth = 20, Width = 20 , Lenght= 20 }, 
               new Models.Measurement { Temperature = 59 , Humidity = 20 , Weight = 60 , Depth = 45, Width = 10 , Lenght= 9 } };

            IndexMeasurementViewModel viewModel = new IndexMeasurementViewModel
            {
                Items = model
            };

            return this.View(viewModel);
        }

        public IActionResult AddMeasurement()
        {
            return RedirectToAction("Index", "Measurement");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
