using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class CommunityPartnershipConfiguration : IEntityTypeConfiguration<CommunityPartnership>
{
    public void Configure(EntityTypeBuilder<CommunityPartnership> builder)
    {
        // Table Name
        builder.ToTable("community_partnership");

        // Property Configurations
        builder.Property(x => x.PartnershipNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PartnerName)
               .HasMaxLength(100);

        builder.Property(x => x.PartnerType)
               .HasMaxLength(100);

        builder.Property(x => x.SupportType)
               .HasMaxLength(100);

        builder.Property(x => x.AgreementDocumentPath)
               .HasMaxLength(100);

        builder.Property(x => x.SupportValueAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.SupportValueCurrency)
               .HasMaxLength(100);

        builder.Property(x => x.SupportInKindJson)
               .HasMaxLength(100);

        builder.Property(x => x.Impact)
               .HasMaxLength(100);

        builder.Property(x => x.PartnerContactPerson)
               .HasMaxLength(100);

        builder.Property(x => x.PartnerContactEmail)
               .HasMaxLength(100);

        builder.Property(x => x.PartnerContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
