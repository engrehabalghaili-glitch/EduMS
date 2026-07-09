using System.Linq.Expressions;
using EduMS.Domain.Common;
using EduMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.Common.Persistence;

public class Repository<T>(EduMSDbContext dbContext) : IRepository<T> where T : BaseEntity
{
    protected readonly EduMSDbContext DbContext = dbContext;

    public async Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }
}
