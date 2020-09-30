using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UmbaniApiTest.Models;
using static UmbaniApiTest.Global;

namespace UmbaniApiTest.ViewModels
{
    public class EditMeasurmentViewModel
    {
        public Guid MeasurementId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Weight { get; set; }
        public double Depth { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public Catagory ItemCatagory { get; set; }
        public bool Pass { get; set; }
    }
}
