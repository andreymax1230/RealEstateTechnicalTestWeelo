using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateTechnicalTest.Domain.Entities;

namespace RealEstateTechnicalTest.Infraestructure.Configuration
{
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable(string.Format("{0}", nameof(PropertyImage)));
            builder.Property(c => c.File).HasMaxLength(128).IsRequired();
        }
    }
}
