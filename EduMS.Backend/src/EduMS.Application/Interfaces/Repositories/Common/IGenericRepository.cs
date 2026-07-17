using System.Threading;
using System.Linq.Expressions;

namespace EduMS.Application.Interfaces.Repositories.Common;

public interface IGenericRepository<T> where T : class
{
    // 1. جلب حسب المعرف (متزامن مع إمكانية التتبع)
    Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    // 2. جلب الكل (تُستخدم للجداول الصغيرة فقط كالأنواع والحالات)
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    // 3. جلب مع الفلترة (FindAsync)
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    // 4. جلب مع العلاقات (Eager Loading / Includes) لتجنب تكرار الدوال في الواجهات المخصصة
    Task<IEnumerable<T>> FindWithIncludesAsync(
        Expression<Func<T, bool>> predicate, 
        params Expression<Func<T, object>>[] includes, CancellationToken cancellationToken = default);

    // 5. التصفح (Pagination) للملفات الكبيرة 
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);

    // 6. التحقق من الوجود (سريعة جداً للأداء)
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    // 7. عمليات التعديل والإضافة والحذف
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}



