using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeePerformanceReviewRepository : IGenericRepository<EmployeePerformanceReview>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التقييمات بناءً على حالة الاعتماد (مسودة، معتمد، نهائي)
    Task<IEnumerable<EmployeePerformanceReview>> GetReviewsByStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب التقييمات المعترض عليها (متنازع عليها)
    Task<IEnumerable<EmployeePerformanceReview>> GetDisputedReviewsAsync(CancellationToken cancellationToken = default);
    
    // جلب التقييمات في فترة أكاديمية أو مالية معينة
    Task<IEnumerable<EmployeePerformanceReview>> GetReviewsByPeriodAsync(DateTime periodStart, DateTime periodEnd, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة تقييمات موظف محدد
    Task<IEnumerable<EmployeePerformanceReview>> GetReviewsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب التقييمات التي قام بها مقيِّم محدد (المدير المباشر)
    Task<IEnumerable<EmployeePerformanceReview>> GetReviewsByReviewerAsync(long reviewerEmployeeId, CancellationToken cancellationToken = default);
    
    // جلب تقييمات مدرسة محددة في سنة أكاديمية محددة
    Task<IEnumerable<EmployeePerformanceReview>> GetSchoolReviewsAsync(long schoolId, long academicYearId, CancellationToken cancellationToken = default);
}
