using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // Table Name
        builder.ToTable("account");

        // Property Configurations
        builder.Property(x => x.AccountCode)
               .HasMaxLength(100);

        builder.Property(x => x.AccountNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.AccountNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.CurrentBalance)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
