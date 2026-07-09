using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
{
    public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
    {
        builder.ToTable("JOURNAL_ENTRY_LINE");

        builder.HasKey(jl => jl.Id);
        builder.Property(jl => jl.Id).HasColumnName("ENTRY_LINE_ID");

        builder.Property(jl => jl.JournalEntryId)
            .HasColumnName("JOURNAL_ENTRY_ID")
            .IsRequired();

        builder.Property(jl => jl.AccountId)
            .HasColumnName("ACCOUNT_ID")
            .IsRequired();

        builder.Property(jl => jl.DebitAmount)
            .HasColumnName("DEBIT_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(jl => jl.CreditAmount)
            .HasColumnName("CREDIT_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(jl => jl.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(150)
            .IsRequired();

        // Relationship mappings
        builder.HasOne(jl => jl.JournalEntry)
            .WithMany(j => j.Lines)
            .HasForeignKey(jl => jl.JournalEntryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(jl => jl.Account)
            .WithMany()
            .HasForeignKey(jl => jl.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
