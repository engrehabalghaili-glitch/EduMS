using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentLibraryBorrowingLogConfiguration : IEntityTypeConfiguration<StudentLibraryBorrowingLog>
{
    public void Configure(EntityTypeBuilder<StudentLibraryBorrowingLog> builder)
    {
        // Table Name
        builder.ToTable("student_library_borrowing_log");

        // Property Configurations
        builder.Property(x => x.LatePenaltyFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Remarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
