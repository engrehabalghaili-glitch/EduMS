using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeLeaveConfiguration : IEntityTypeConfiguration<EmployeeLeave>
{
    public void Configure(EntityTypeBuilder<EmployeeLeave> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Leaves)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeePerformanceReviewConfiguration : IEntityTypeConfiguration<EmployeePerformanceReview>
{
    public void Configure(EntityTypeBuilder<EmployeePerformanceReview> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OverallScore).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.PerformanceReviews)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeViolationConfiguration : IEntityTypeConfiguration<EmployeeViolation>
{
    public void Configure(EntityTypeBuilder<EmployeeViolation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PenaltyDeductionAmount).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Violations)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeTrainingConfiguration : IEntityTypeConfiguration<EmployeeTraining>
{
    public void Configure(EntityTypeBuilder<EmployeeTraining> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TrainingCost).HasPrecision(18, 2);
        builder.Property(x => x.Score).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Trainings)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeInternalTransferConfiguration : IEntityTypeConfiguration<EmployeeInternalTransfer>
{
    public void Configure(EntityTypeBuilder<EmployeeInternalTransfer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.InternalTransfers)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeExternalTransferConfiguration : IEntityTypeConfiguration<EmployeeExternalTransfer>
{
    public void Configure(EntityTypeBuilder<EmployeeExternalTransfer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.ExternalTransfers)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeTerminationConfiguration : IEntityTypeConfiguration<EmployeeTermination>
{
    public void Configure(EntityTypeBuilder<EmployeeTermination> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.GratuityAmount).HasPrecision(18, 2);
        builder.Property(x => x.FinalSalarySettlement).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Terminations)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
{
    public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Documents)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeAttendanceConfiguration : IEntityTypeConfiguration<EmployeeAttendance>
{
    public void Configure(EntityTypeBuilder<EmployeeAttendance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TotalWorkHours).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Attendances)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeePayrollConfiguration : IEntityTypeConfiguration<EmployeePayroll>
{
    public void Configure(EntityTypeBuilder<EmployeePayroll> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BasicSalary).HasPrecision(18, 2);
        builder.Property(x => x.HousingAllowance).HasPrecision(18, 2);
        builder.Property(x => x.TransportAllowance).HasPrecision(18, 2);
        builder.Property(x => x.OtherAllowances).HasPrecision(18, 2);
        builder.Property(x => x.OvertimePay).HasPrecision(18, 2);
        builder.Property(x => x.GrossTotal).HasPrecision(18, 2);
        builder.Property(x => x.DeductionAbsence).HasPrecision(18, 2);
        builder.Property(x => x.DeductionInsurance).HasPrecision(18, 2);
        builder.Property(x => x.DeductionOther).HasPrecision(18, 2);
        builder.Property(x => x.NetSalary).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class OfficialCircularConfiguration : IEntityTypeConfiguration<OfficialCircular>
{
    public void Configure(EntityTypeBuilder<OfficialCircular> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.IssuerEmployee)
            .WithMany(e => e.IssuedCirculars)
            .HasForeignKey(x => x.IssuerEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class AppointmentDecisionConfiguration : IEntityTypeConfiguration<AppointmentDecision>
{
    public void Configure(EntityTypeBuilder<AppointmentDecision> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SalaryAmount).HasPrecision(18, 2);
        builder.HasOne(x => x.Employee)
            .WithMany(e => e.AppointmentDecisions)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
