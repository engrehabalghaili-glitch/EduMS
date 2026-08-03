using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M2_StudentAffairs.Configurations;

public class StudentTransferLogConfiguration : IEntityTypeConfiguration<StudentTransferLog>
{
    public void Configure(EntityTypeBuilder<StudentTransferLog> builder)
    {
        builder.ToTable("STUDENT_TRANSFER_LOG");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Reason)
            .HasMaxLength(300)
            .IsRequired();

        builder.HasIndex(t => t.StudentId);
        builder.HasIndex(t => t.TransferDate);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(t => t.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(t => t.FromSchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(t => t.ToSchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
