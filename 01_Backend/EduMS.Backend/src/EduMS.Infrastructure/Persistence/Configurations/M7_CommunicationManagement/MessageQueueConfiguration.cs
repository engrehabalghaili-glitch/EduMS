using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class MessageQueueConfiguration : IEntityTypeConfiguration<MessageQueue>
{
    public void Configure(EntityTypeBuilder<MessageQueue> builder)
    {
        // Table Name
        builder.ToTable("message_queue");

        // Property Configurations
        builder.Property(x => x.MessageType)
               .HasMaxLength(100);

        builder.Property(x => x.RecipientAddress)
               .HasMaxLength(500);

        builder.Property(x => x.Subject)
               .HasMaxLength(100);

        builder.Property(x => x.Body)
               .HasMaxLength(100);

        builder.Property(x => x.Status)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
