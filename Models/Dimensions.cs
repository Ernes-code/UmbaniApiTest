using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Models
{
    public class Dimensions
    {
        public double Depth { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }

        public double CalculateVolume()
        {
            return this.Lenght * this.Width * this.Depth;
        }
    }
}
