using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        // Table Name
        builder.ToTable("vendor");

        // Property Configurations
        builder.Property(x => x.VendorName)
               .HasMaxLength(100);

        builder.Property(x => x.TaxNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ContactName)
               .HasMaxLength(100);

        builder.Property(x => x.ContactEmail)
               .HasMaxLength(100);

        builder.Property(x => x.ContactPhone)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
