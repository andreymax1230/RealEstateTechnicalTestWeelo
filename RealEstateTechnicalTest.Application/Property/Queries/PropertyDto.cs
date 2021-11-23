using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Application.Property.Queries
{
    public class PropertyDto
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
    }
}