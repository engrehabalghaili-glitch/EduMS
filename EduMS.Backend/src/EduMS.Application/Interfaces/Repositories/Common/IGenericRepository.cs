using System.Linq.Expressions;

namespace EduMS.Application.Interfaces.Repositories.Common;

public interface IGenericRepository<T> where T : class
{
    // 1. جلب حسب المعرف (متزامن مع إمكانية التتبع)
    Task<T?> GetByIdAsync(long id);

    // 2. جلب الكل (تُستخدم للجداول الصغيرة فقط كالأنواع والحالات)
    Task<IEnumerable<T>> GetAllAsync();

    // 3. جلب مع الفلترة (FindAsync)
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    // 4. جلب مع العلاقات (Eager Loading / Includes) لتجنب تكرار الدوال في الواجهات المخصصة
    Task<IEnumerable<T>> FindWithIncludesAsync(
        Expression<Func<T, bool>> predicate, 
        params Expression<Func<T, object>>[] includes);

    // 5. التصفح (Pagination) للملفات الكبيرة 
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        Expression<Func<T, bool>>? predicate = null);

    // 6. التحقق من الوجود (سريعة جداً للأداء)
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    // 7. عمليات التعديل والإضافة والحذف
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}

