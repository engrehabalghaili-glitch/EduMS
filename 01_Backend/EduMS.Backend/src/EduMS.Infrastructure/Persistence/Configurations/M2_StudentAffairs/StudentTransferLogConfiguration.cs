using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentTransferLogConfiguration : IEntityTypeConfiguration<StudentTransferLog>
{
    public void Configure(EntityTypeBuilder<StudentTransferLog> builder)
    {
        // Table Name
        builder.ToTable("student_transfer_log");

        // Property Configurations
        builder.Property(x => x.Reason)
               .HasMaxLength(500);

        builder.Property(x => x.TransferCertificateNumber)
               .HasMaxLength(100);

        builder.Property(x => x.MinistryApprovalReference)
               .HasMaxLength(100);

        builder.Property(x => x.TransferRemarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
