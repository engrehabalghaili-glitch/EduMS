using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class UserEmployeeIdentityLinkConfiguration : IEntityTypeConfiguration<UserEmployeeIdentityLink>
{
    public void Configure(EntityTypeBuilder<UserEmployeeIdentityLink> builder)
    {
        // Table Name
        builder.ToTable("user_employee_identity_link");

        // Property Configurations
        builder.Property(x => x.UnlinkReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
