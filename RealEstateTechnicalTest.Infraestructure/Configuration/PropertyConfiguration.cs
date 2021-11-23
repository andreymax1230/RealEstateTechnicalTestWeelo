using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateTechnicalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateTechnicalTest.Infraestructure.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(string.Format("{0}", nameof(Property)));
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(256).IsRequired();
            builder.Property(c => c.CodeInternal).HasMaxLength(64).IsRequired();
        }
    }
}
