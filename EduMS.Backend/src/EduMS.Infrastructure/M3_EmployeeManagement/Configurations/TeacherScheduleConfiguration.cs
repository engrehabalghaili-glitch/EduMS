using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class TeacherScheduleConfiguration : IEntityTypeConfiguration<TeacherSchedule>
{
    public void Configure(EntityTypeBuilder<TeacherSchedule> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Teacher)
            .WithMany(e => e.Schedules)
            .HasForeignKey(x => x.TeacherEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
