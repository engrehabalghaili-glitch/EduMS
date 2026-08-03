using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class OrganizationalSectorConfiguration : IEntityTypeConfiguration<OrganizationalSector>
{
    public void Configure(EntityTypeBuilder<OrganizationalSector> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.AnnualHrBudget).HasPrecision(18, 2);

        builder.HasOne(x => x.ParentSector)
            .WithMany(s => s.SubSectors)
            .HasForeignKey(x => x.ParentSectorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Directorate)
            .WithMany()
            .HasForeignKey(x => x.DirectorateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.School)
            .WithMany()
            .HasForeignKey(x => x.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.HeadOfSectorEmployee)
            .WithMany()
            .HasForeignKey(x => x.HeadOfSectorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.AssignedEmployees)
            .WithOne(e => e.OrganizationalSector)
            .HasForeignKey(e => e.OrganizationalSectorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
