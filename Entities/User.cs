using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public double Username { get; set; }

        public IEnumerable<Measurement> Measurements { get; set; }
    }
}
