using RealEstateTechnicalTest.Domain.Entities;
using RealEstateTechnicalTest.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateTechnicalTest.UnitTest.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(Entities context)
        {
            context.Add<Owner>(new Owner()
            {
                Id = Guid.NewGuid(),
                Name ="Test Owner",
                Address = "13th Street. 47 W 13th St, New York, NY",
                Birthday = DateTime.Now.AddYears(-30),
                Photo = "image.jpg"
            });
            context.SaveChanges();
        }
    }
}
