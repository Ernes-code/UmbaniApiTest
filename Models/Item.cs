using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Models
{
    public abstract class Item
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Depth { get; set; }

        public abstract double CalculateMean(List<double> Field);
        public abstract double CalculateSum(List<double> Field);
        public abstract double CalculateMin(List<double> Field);
        public abstract double CalculateMax(List<double> Field);
        public abstract double CalculateStdv(List<double> Field);
        public abstract double CalculateVar(List<double> Field);
    }
}
