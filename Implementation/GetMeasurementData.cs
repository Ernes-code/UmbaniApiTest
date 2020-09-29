using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmbaniApiTest.Models;
using UmbaniApiTest.Services;

namespace UmbaniApiTest.Implementation
{
    public class GetMeasurementData : IGetMeasurementData
    {
        public IEnumerable<Item> Items { get; set; }
    }
}
