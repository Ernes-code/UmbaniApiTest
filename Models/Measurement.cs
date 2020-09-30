using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static UmbaniApiTest.Global;

namespace UmbaniApiTest.Models
{
    public class Measurement: Item
    {
        public Guid MeasurementId { get; set; }
        public Catagory MeasurmentCatagory { get; set; }

        public bool Pass { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Username { get; set; }

        public Dimensions Dimensions { get; set; }

        public override double CalculateMax(List<double> Field)
        {
            return Field.Max();
        }

        public override double CalculateMean(List<double> Field)
        {
            return Field.Average();
        }

        public override double CalculateMin(List<double> Field)
        {
            return Field.Min();
        }

        public override double CalculateStdv(List<double> Field)
        {
            List<double> stdvList = new List<double>();
            foreach (double item in Field)
                stdvList.Add(Math.Sqrt((item - Field.Average())));

            return Math.Sqrt(stdvList.Average());
        }

        public override double CalculateSum(List<double> Field)
        {
            return Field.Sum();
        }

        public override double CalculateVar(List<double> Field)
        {
            List<double> stdvList = new List<double>();
            foreach (double item in Field)
                stdvList.Add(Math.Sqrt((item - Field.Average())));

            return stdvList.Average();
        }
    }
}
