using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Entities
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Measurement> Measurement { get; set; }
    }
}
