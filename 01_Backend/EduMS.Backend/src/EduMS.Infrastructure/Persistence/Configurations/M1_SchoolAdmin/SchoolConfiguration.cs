using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        // Table Name
        builder.ToTable("school");

        // Property Configurations
        builder.Property(x => x.SchoolNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SchoolNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.SchoolCode)
               .HasMaxLength(100);

        builder.Property(x => x.Directorate)
               .HasMaxLength(100);

        builder.Property(x => x.Governorate)
               .HasMaxLength(100);

        builder.Property(x => x.ContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.ContactEmail)
               .HasMaxLength(100);

        builder.Property(x => x.WebsiteUrl)
               .HasMaxLength(100);

        builder.Property(x => x.PostalAddress)
               .HasMaxLength(500);

        builder.Property(x => x.TaxRegistrationNumber)
               .HasMaxLength(100);

        builder.Property(x => x.CommercialLicenseNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
