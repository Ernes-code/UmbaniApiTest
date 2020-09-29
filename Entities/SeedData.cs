using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmbaniApiTest.Entities
{
    public static class SeedData
    {
        private static Guid User1 = Guid.NewGuid();
        private static Guid User2 = Guid.NewGuid();

        public static void Seed(ApplicationDbContext dbContext)
        {
            using (dbContext)
            {
                dbContext.AddRange
                    (
                    new Person { PersonId = User1, PersonUsername = "ernessmit2@gmail.com" },
                    new Person { PersonId = User2, PersonUsername = "theodorusernstsmit@gmail.com" }
                    );
                dbContext.AddRange
                    (
                    new Measurement { MeasurementId = Guid.NewGuid(), Temperature = 22, Humidity = 50, Weight = 67, Depth = 33, Lenght = 33, Width = 33, UserId = User1, Catagory = Global.Catagory.Line1, Pass = true },
                    new Measurement { MeasurementId = Guid.NewGuid(), Temperature = 34, Humidity = 100, Weight = 38, Depth = 58, Lenght = 98, Width = 34, UserId = User2, Catagory = Global.Catagory.Line2, Pass = true },
                    new Measurement { MeasurementId = Guid.NewGuid(), Temperature = 56, Humidity = 44, Weight = 90, Depth = 67, Lenght = 09, Width = 67, UserId = User1, Catagory = Global.Catagory.Line3, Pass = true }
                    );
                _ = dbContext.SaveChanges();
                dbContext.Dispose();
            }

        }
    }
}
