using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeAdditionalTaskConfiguration : IEntityTypeConfiguration<EmployeeAdditionalTask>
{
    public void Configure(EntityTypeBuilder<EmployeeAdditionalTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompensationAmount).HasPrecision(18, 2);

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.AdditionalTasks)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeMentorConfiguration : IEntityTypeConfiguration<EmployeeMentor>
{
    public void Configure(EntityTypeBuilder<EmployeeMentor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Mentor)
            .WithMany()
            .HasForeignKey(x => x.MentorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Mentee)
            .WithMany()
            .HasForeignKey(x => x.MenteeEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class SelfServicePortalRequestConfiguration : IEntityTypeConfiguration<SelfServicePortalRequest>
{
    public void Configure(EntityTypeBuilder<SelfServicePortalRequest> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.SelfServiceRequests)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
