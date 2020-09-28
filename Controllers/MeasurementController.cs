using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UmbaniApiTest.Controllers
{
    public class MeasurementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMeasurment()
        {
            return ModelState.IsValid ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Measurment");
        }
    }
}