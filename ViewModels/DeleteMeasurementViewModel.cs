using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.ViewModels
{
    public class DeleteMeasurementViewModel
    {
        public Guid PersonId { get; set; }
        public Guid MeasurementId { get; set; }
    }
}
