using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class EducationalSupervisionVisitConfiguration : IEntityTypeConfiguration<EducationalSupervisionVisit>
{
    public void Configure(EntityTypeBuilder<EducationalSupervisionVisit> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EvaluationScore).HasPrecision(18, 2);

        builder.HasOne(x => x.Directorate)
            .WithMany()
            .HasForeignKey(x => x.DirectorateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.School)
            .WithMany()
            .HasForeignKey(x => x.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SupervisorEmployee)
            .WithMany(e => e.ConductedSupervisionVisits)
            .HasForeignKey(x => x.SupervisorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.VisitedTeacherEmployee)
            .WithMany(e => e.ReceivedSupervisionVisits)
            .HasForeignKey(x => x.VisitedTeacherEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
