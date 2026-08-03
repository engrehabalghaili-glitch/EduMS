using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
{
    public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
    {
        // Table Name
        builder.ToTable("journal_entry_line");

        // Property Configurations
        builder.Property(x => x.DebitAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.CreditAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
