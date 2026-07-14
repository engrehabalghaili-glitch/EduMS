using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class VisitorEntryLogConfiguration : IEntityTypeConfiguration<VisitorEntryLog>
{
    public void Configure(EntityTypeBuilder<VisitorEntryLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.HostEmployee)
            .WithMany()
            .HasForeignKey(x => x.HostEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SecurityOfficerEmployee)
            .WithMany()
            .HasForeignKey(x => x.SecurityOfficerEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
