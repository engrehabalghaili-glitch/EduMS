using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeCommitteeConfiguration : IEntityTypeConfiguration<EmployeeCommittee>
{
    public void Configure(EntityTypeBuilder<EmployeeCommittee> builder)
    {
        // Table Name
        builder.ToTable("employee_committee");

        // Property Configurations
        builder.Property(x => x.CommitteeNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.CommitteeNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.CommitteeCode)
               .HasMaxLength(100);

        builder.Property(x => x.Objectives)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
