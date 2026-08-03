using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolContactInfoConfiguration : IEntityTypeConfiguration<SchoolContactInfo>
{
    public void Configure(EntityTypeBuilder<SchoolContactInfo> builder)
    {
        // Table Name
        builder.ToTable("school_contact_info");

        // Property Configurations
        builder.Property(x => x.OfficialPhone)
               .HasMaxLength(100);

        builder.Property(x => x.Landline)
               .HasMaxLength(100);

        builder.Property(x => x.FaxNumber)
               .HasMaxLength(100);

        builder.Property(x => x.OfficialEmail)
               .HasMaxLength(100);

        builder.Property(x => x.AlternativeEmail)
               .HasMaxLength(100);

        builder.Property(x => x.FullAddress)
               .HasMaxLength(500);

        builder.Property(x => x.StreetName)
               .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
               .HasMaxLength(100);

        builder.Property(x => x.DistrictName)
               .HasMaxLength(100);

        builder.Property(x => x.City)
               .HasMaxLength(100);

        builder.Property(x => x.GpsLatitude)
               .HasMaxLength(100);

        builder.Property(x => x.GpsLongitude)
               .HasMaxLength(100);

        builder.Property(x => x.LocationMapUrl)
               .HasMaxLength(100);

        builder.Property(x => x.WorkingHoursJson)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactName)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.SocialLinksJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
