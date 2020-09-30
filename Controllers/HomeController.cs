using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            this._logger = logger;
            this._dbContext = dbContext;
        }
        public IActionResult GridView()
        {
            var model = this._dbContext.Measurement.Select(x => new Models.Measurement {Temperature = x.Temperature, Humidity = x.Humidity, 
                Weight = x.Weight, Depth = x.Depth, Width = x.Width, Lenght = x.Lenght, MeasurmentCatagory = x.Catagory, Pass = x.Pass, MeasurementId = x.MeasurementId
            });

            Models.Measurement calc = new Models.Measurement();

            double TemperatureSum = calc.CalculateSum(model.Select(x => x.Temperature).ToList());
            double TemperatureAverage = calc.CalculateMean(model.Select(x => x.Temperature).ToList());
            double TemperatureMin = calc.CalculateMin(model.Select(x => x.Temperature).ToList());
            double TemperatureMax = calc.CalculateMax(model.Select(x => x.Temperature).ToList());
            double TemperatureStdv = calc.CalculateStdv(model.Select(x => x.Temperature).ToList());
            double TemperatureVariance = calc.CalculateVar(model.Select(x => x.Temperature).ToList());

            ViewBag.TemperatureSum = TemperatureSum;
            ViewBag.TemperatureAverage = TemperatureAverage;
            ViewBag.TemperatureMin = TemperatureMin;
            ViewBag.TemperatureMax = TemperatureMax;
            ViewBag.TemperatureStdv = TemperatureStdv;
            ViewBag.TemperatureVariance = TemperatureVariance;


            IndexMeasurementViewModel viewModel = new IndexMeasurementViewModel
            {
                Items = model
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SeedData.Seed(this._dbContext);
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement()
        {
            return RedirectToAction("Index", "Measurement");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
