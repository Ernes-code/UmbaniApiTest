using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string PersonUsername { get; set; }

        public IEnumerable<Measurement> Measurements { get; set; }
    }
}
