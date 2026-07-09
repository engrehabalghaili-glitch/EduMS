using EduMS.Domain.Common;
using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.Common.Persistence;

public class EduMSDbContext(DbContextOptions<EduMSDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<SystemUser> SystemUsers => Set<SystemUser>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Guardian> Guardians => Set<Guardian>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<School> Schools => Set<School>();
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
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
