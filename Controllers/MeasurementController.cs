using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UmbaniApiTest.Models;
using UmbaniApiTest.ViewModels;

namespace UmbaniApiTest.Controllers
{
    public class MeasurementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMeasurment(AddMeasurmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var measurement = new Measurement { };
            }
            return ModelState.IsValid ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Measurment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMeasurment(EditMeasurmentViewModel model)
        {

            return ModelState.IsValid ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Measurment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMeasurment(DeleteMeasurementViewModel model)
        {

            return ModelState.IsValid ? RedirectToAction("Index", "Home") : RedirectToAction("Index", "Measurment");
        }
    }
}