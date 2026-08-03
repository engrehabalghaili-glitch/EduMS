using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Table Name
        builder.ToTable("person");

        // Property Configurations
        builder.Property(x => x.FullNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FullNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.NationalId)
               .HasMaxLength(100);

        builder.Property(x => x.ContactNumber)
               .HasMaxLength(100);

        builder.Property(x => x.MedicalInfo)
               .HasMaxLength(100);

        builder.Property(x => x.PlaceOfBirth)
               .HasMaxLength(100);

        builder.Property(x => x.NationalityCode)
               .HasMaxLength(100);

        builder.Property(x => x.EmailAddress)
               .HasMaxLength(500);

        builder.Property(x => x.BloodGroup)
               .HasMaxLength(100);

        builder.Property(x => x.ResidentialAddress)
               .HasMaxLength(500);

        builder.Property(x => x.PassportNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
