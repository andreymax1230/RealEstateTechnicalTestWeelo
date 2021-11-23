using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateTechnicalTest.Domain.Entities;

namespace RealEstateTechnicalTest.Infraestructure.Configuration
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable(string.Format("{0}", nameof(PropertyTrace)));
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
        }
    }
}
