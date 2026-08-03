using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetBudgetAllocationRepository : IGenericRepository<AssetBudgetAllocation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المخصصات المالية النشطة التي لم تنفد بعد
    Task<IEnumerable<AssetBudgetAllocation>> GetActiveAllocationsAsync(CancellationToken cancellationToken = default);
    
    // جلب مخصصات الميزانية بناءً على نوعها (رأسمالي، تشغيلي)
    Task<IEnumerable<AssetBudgetAllocation>> GetAllocationsByTypeAsync(int budgetType, CancellationToken cancellationToken = default);
    
    // جلب المخصصات الخاصة بسنة مالية محددة
    Task<IEnumerable<AssetBudgetAllocation>> GetAllocationsByFiscalYearAsync(string fiscalYear, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب المخصصات المرتبطة بمدرسة محددة
    Task<IEnumerable<AssetBudgetAllocation>> GetAllocationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المخصصات المرتبطة بقسم معين
    Task<IEnumerable<AssetBudgetAllocation>> GetAllocationsByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
}
