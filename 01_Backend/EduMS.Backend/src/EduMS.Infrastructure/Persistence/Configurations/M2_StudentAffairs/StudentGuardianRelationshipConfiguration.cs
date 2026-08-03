using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentGuardianRelationshipConfiguration : IEntityTypeConfiguration<StudentGuardianRelationship>
{
    public void Configure(EntityTypeBuilder<StudentGuardianRelationship> builder)
    {
        // Table Name
        builder.ToTable("student_guardian_relationship");

        // Property Configurations
        builder.Property(x => x.CustodyDocumentReference)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
