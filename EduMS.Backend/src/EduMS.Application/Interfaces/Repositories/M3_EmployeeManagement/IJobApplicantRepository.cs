using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IJobApplicantRepository : IGenericRepository<JobApplicant>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات التوظيف بناءً على حالتها (مقدم، مقبول مبدئياً، مرفوض، الخ)
    Task<IEnumerable<JobApplicant>> GetApplicantsByStatusAsync(int applicationStatus, CancellationToken cancellationToken = default);
    
    // جلب المتقدمين الذين لديهم موعد مقابلة في فترة زمنية معينة
    Task<IEnumerable<JobApplicant>> GetApplicantsByInterviewDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة طلبات التوظيف لوظيفة شاغرة محددة
    Task<IEnumerable<JobApplicant>> GetApplicantsByVacancyIdAsync(long vacantPositionId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي تمت مراجعتها من قبل موظف محدد
    Task<IEnumerable<JobApplicant>> GetApplicantsReviewedByEmployeeAsync(long reviewedByEmployeeId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار التقديم لنفس الوظيفة باستخدام رقم الهوية
    Task<bool> HasApplicantAlreadyAppliedAsync(long vacantPositionId, string nationalIdNumber, CancellationToken cancellationToken = default);
}
