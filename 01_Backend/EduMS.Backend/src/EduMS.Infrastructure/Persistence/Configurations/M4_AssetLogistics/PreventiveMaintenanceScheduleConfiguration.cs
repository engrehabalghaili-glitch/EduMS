using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PreventiveMaintenanceScheduleConfiguration : IEntityTypeConfiguration<PreventiveMaintenanceSchedule>
{
    public void Configure(EntityTypeBuilder<PreventiveMaintenanceSchedule> builder)
    {
        // Table Name
        builder.ToTable("preventive_maintenance_schedule");

        // Property Configurations
        builder.Property(x => x.ScheduleCode)
               .HasMaxLength(100);

        builder.Property(x => x.TaskNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.TaskNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.FrequencyValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.AssignedToTeamText)
               .HasMaxLength(100);

        builder.Property(x => x.InstructionsText)
               .HasMaxLength(100);

        builder.Property(x => x.ChecklistJson)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
