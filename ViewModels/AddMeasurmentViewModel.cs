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
    public class AddMeasurmentViewModel
    {
        [Required( ErrorMessage = "The Temperature is Required")]
        public double Temperature { get; set; }

        [Required(ErrorMessage = "The Humidity is Required")]
        public double Humidity { get; set; }

        [Required(ErrorMessage = "The Weight is Required")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "The Depth is Required")]
        public double Depth { get; set; }

        [Required(ErrorMessage = "The Lenght is Required")]
        public double Lenght { get; set; }

        [Required(ErrorMessage = "The Width is Required")]
        public double Width { get; set; }

        [Required(ErrorMessage = "The Catagory is Required")]
        public Catagory ItemCatagory { get; set; }

        [Required(ErrorMessage = "The Passing Criteria is Required")]
        public bool Pass { get; set; }
    }
}
