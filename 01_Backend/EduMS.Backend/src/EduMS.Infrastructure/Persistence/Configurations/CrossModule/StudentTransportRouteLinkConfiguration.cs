using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentTransportRouteLinkConfiguration : IEntityTypeConfiguration<StudentTransportRouteLink>
{
    public void Configure(EntityTypeBuilder<StudentTransportRouteLink> builder)
    {
        // Table Name
        builder.ToTable("student_transport_route_link");

        // Property Configurations
        builder.Property(x => x.AssignedSeatNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
