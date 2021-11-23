using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Domain.Entities
{
    public class Property : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; }

    }
}
