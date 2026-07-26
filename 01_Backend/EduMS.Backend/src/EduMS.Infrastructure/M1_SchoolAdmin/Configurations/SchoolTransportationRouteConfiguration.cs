using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class SchoolTransportationRouteConfiguration : IEntityTypeConfiguration<SchoolTransportationRoute>
{
    public void Configure(EntityTypeBuilder<SchoolTransportationRoute> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.MonthlyFee).HasPrecision(18, 2);

        builder.HasOne(x => x.DriverEmployee)
            .WithMany()
            .HasForeignKey(x => x.DriverEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BusSupervisorEmployee)
            .WithMany()
            .HasForeignKey(x => x.BusSupervisorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
