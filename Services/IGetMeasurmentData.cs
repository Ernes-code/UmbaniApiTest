using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmbaniApiTest.Models;

namespace UmbaniApiTest.Services
{
    public interface IGetMeasurementData
    {
        IEnumerable<Item> Items { get; set; }
    }
}
