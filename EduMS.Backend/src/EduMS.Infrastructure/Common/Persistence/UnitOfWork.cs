using EduMS.Domain.Interfaces;

namespace EduMS.Infrastructure.Common.Persistence;

public class UnitOfWork(EduMSDbContext dbContext) : IUnitOfWork
{
    private readonly EduMSDbContext _dbContext = dbContext;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
