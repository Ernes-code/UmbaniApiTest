using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static UmbaniApiTest.Global;

namespace UmbaniApiTest.Entities
{
    public class Measurement
    {
        public Guid MeasurementId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Weight { get; set; }
        public double Depth { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public Catagory Catagory { get; set; }
        public bool Pass { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
