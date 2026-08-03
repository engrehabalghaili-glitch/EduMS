using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolLibraryItemConfiguration : IEntityTypeConfiguration<SchoolLibraryItem>
{
    public void Configure(EntityTypeBuilder<SchoolLibraryItem> builder)
    {
        // Table Name
        builder.ToTable("school_library_item");

        // Property Configurations
        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.TitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.AuthorName)
               .HasMaxLength(100);

        builder.Property(x => x.PublisherName)
               .HasMaxLength(100);

        builder.Property(x => x.IsbnNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ShelfLocationCode)
               .HasMaxLength(100);

        builder.Property(x => x.UnitPurchaseCost)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
