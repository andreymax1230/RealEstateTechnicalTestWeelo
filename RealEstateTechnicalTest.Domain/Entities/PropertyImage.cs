using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Domain.Entities
{
    public class PropertyImage : BaseEntity
    {
        public string File { get; set; }
        public bool Enabled { get; set; }
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
