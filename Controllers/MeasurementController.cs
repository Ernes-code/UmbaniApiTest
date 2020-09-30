using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UmbaniApiTest.Entities;
using UmbaniApiTest.Models;
using UmbaniApiTest.ViewModels;

namespace UmbaniApiTest.Controllers
{
    public class MeasurementController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MeasurementController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMeasurement(AddMeasurmentViewModel model)
        {
            var measurement = new Models.Measurement
            {
                Temperature = model.Temperature,
                Humidity = model.Depth,
                Weight = model.Weight
            ,
                Depth = model.Depth,
                Width = model.Width,
                Lenght = model.Lenght,
                Pass = model.Pass,
                MeasurmentCatagory = model.ItemCatagory
                };

                try
                {
                using(this._dbContext)
                {
                    var result = this._dbContext.Set<Entities.Measurement>().FromSqlRaw("EXECUTE [dbo].[AddMeasurement] @p0 @p1 @p2 @p3 @p4 @p5 @p5 @p6 @p7"
                        , measurement.Temperature, measurement.Humidity, measurement.Weight
                      , measurement.Depth, measurement.Width, measurement.Lenght, (int)measurement.MeasurmentCatagory, measurement.Pass);
                    _ = this._dbContext.SaveChanges();
                }
                }
                catch (Exception e)
                {
                    return this.View(new ErrorViewModel { RequestId = e.Message ?? this.HttpContext.TraceIdentifier });
                }

                return this.RedirectToAction("GridView", "Home");
        }

        public IActionResult EditMeasurment(EditMeasurmentViewModel model)
        {
                Models.Measurement measurement = new Models.Measurement
                {
                    Temperature = model.Temperature,
                    Humidity = model.Depth,
                    Weight = model.Weight
                ,
                    Depth = model.Depth,
                    Width = model.Width,
                    Lenght = model.Lenght,
                    Pass = model.Pass,
                    MeasurmentCatagory = model.ItemCatagory
                };
                try
                {
                    using(this._dbContext)
                    _ = this._dbContext.Measurement.FromSqlRaw("UpdateMeasurement @p0 @p1 @p2 @p3 @p4 @p5 @p5 @p6 @p7"
                            , model.MeasurementId, measurement.Temperature, measurement.Humidity, measurement.Weight
                            , measurement.Depth, measurement.Width, measurement.Lenght, (int) measurement.MeasurmentCatagory, measurement.Pass).ToList();
                }
                catch (Exception e)
                {
                    return this.View(new ErrorViewModel { RequestId = e.Message ?? this.HttpContext.TraceIdentifier });
                }

                return this.RedirectToAction("GridView", "Home");
        }

        public IActionResult DeleteMeasurment(DeleteMeasurementViewModel model)
        {
                try
                {
                    using (this._dbContext)
                        _ = this._dbContext.Measurement.FromSqlRaw("DeleteMeasurement @p0 @p1"
                            , model.MeasurementId, model.PersonId).ToList();
                }
                catch (Exception e)
                {
                    return this.View(new ErrorViewModel { RequestId = e.Message ?? this.HttpContext.TraceIdentifier });
                }

                return this.RedirectToAction("Index", "Home");
        }
    }
}