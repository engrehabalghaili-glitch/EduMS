using EduMS.Domain.Common;
using EduMS.Domain.Entities;
// using EduMS.Domain.Entities.M1_SchoolAdmin;

using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.Common.Persistence;

public class EduMSDbContext(DbContextOptions<EduMSDbContext> options, EduMS.Application.Interfaces.Security.ICurrentUserService currentUserService) : DbContext(options)
{
    public DbSet<Person> Persons => Set<Person>();
    
    public long? CurrentSchoolId => currentUserService?.TenantId;

    public DbSet<SystemUser> SystemUsers => Set<SystemUser>();
    public DbSet<SystemRole> SystemRoles => Set<SystemRole>();
    public DbSet<School> Schools => Set<School>();
    public DbSet<SchoolAcademicYear> SchoolAcademicYears => Set<SchoolAcademicYear>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Guardian> Guardians => Set<Guardian>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<AcademicLockPeriod> AcademicLockPeriods => Set<AcademicLockPeriod>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();
    public DbSet<PayrollRun> PayrollRuns => Set<PayrollRun>();
    public DbSet<PayrollDetail> PayrollDetails => Set<PayrollDetail>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<PaymentVoucher> PaymentVouchers => Set<PaymentVoucher>();
    

    public DbSet<SchoolLevel> SchoolLevels => Set<SchoolLevel>();
    public DbSet<FeeType> FeeTypes => Set<FeeType>();

    // M5: Financial Management
    public DbSet<StudentAccount> StudentAccounts => Set<StudentAccount>();
    public DbSet<StudentInvoice> StudentInvoices => Set<StudentInvoice>();
    public DbSet<FeePayment> FeePayments => Set<FeePayment>();

    // M4: Asset Logistics
    public DbSet<SchoolAsset> SchoolAssets => Set<SchoolAsset>();
    public DbSet<AssetAssignment> AssetAssignments => Set<AssetAssignment>();

    // M8: Security and Logging
    public DbSet<SystemAuditLog> SystemAuditLogs => Set<SystemAuditLog>();

    // M7 Communication Management
    public DbSet<CommunicationTemplate> CommunicationTemplates { get; set; } = null!;
    public DbSet<SystemNotification> SystemNotifications { get; set; } = null!;
    public DbSet<MessageQueue> MessageQueues { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
                base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {  
            var schoolIdProperty = entityType.FindProperty("SchoolId");
            if (schoolIdProperty != null && schoolIdProperty.ClrType == typeof(long?))
            {
                var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = System.Linq.Expressions.Expression.Property(parameter, schoolIdProperty.PropertyInfo!);
                var currentSchoolIdProp = System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this), nameof(CurrentSchoolId));
                
                var equals = System.Linq.Expressions.Expression.Equal(property, currentSchoolIdProp);
                var isNull = System.Linq.Expressions.Expression.Equal(currentSchoolIdProp, System.Linq.Expressions.Expression.Constant(null, typeof(long?)));
                var orElse = System.Linq.Expressions.Expression.OrElse(equals, isNull);
                
                var filter = System.Linq.Expressions.Expression.Lambda(orElse, parameter);
                entityType.SetQueryFilter(filter);
            }
            else if (schoolIdProperty != null && schoolIdProperty.ClrType == typeof(long))
            {
                var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
                var property = System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Property(parameter, schoolIdProperty.PropertyInfo!), typeof(long?));
                var currentSchoolIdProp = System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this), nameof(CurrentSchoolId));
                
                var equals = System.Linq.Expressions.Expression.Equal(property, currentSchoolIdProp);
                var isNull = System.Linq.Expressions.Expression.Equal(currentSchoolIdProp, System.Linq.Expressions.Expression.Constant(null, typeof(long?)));
                var orElse = System.Linq.Expressions.Expression.OrElse(equals, isNull);
                
                var filter = System.Linq.Expressions.Expression.Lambda(orElse, parameter);
                entityType.SetQueryFilter(filter);
            }
        }
        
        // Apply all configurations from the current assembly automatically
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduMSDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseAuditableEntity>();
        
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.VersionToken = Guid.NewGuid();
                entry.Entity.SyncStatus = Domain.Enums.SyncStatus.Pending;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt = DateTimeOffset.UtcNow;
                entry.Entity.VersionToken = Guid.NewGuid();
                entry.Entity.SyncStatus = Domain.Enums.SyncStatus.Pending;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}

