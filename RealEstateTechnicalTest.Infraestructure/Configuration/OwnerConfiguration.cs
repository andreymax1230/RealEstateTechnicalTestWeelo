using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateTechnicalTest.Domain.Entities;

namespace RealEstateTechnicalTest.Infraestructure.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable(string.Format("{0}", nameof(Owner)));
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Photo).HasMaxLength(256).IsRequired();
        }
    }
}
