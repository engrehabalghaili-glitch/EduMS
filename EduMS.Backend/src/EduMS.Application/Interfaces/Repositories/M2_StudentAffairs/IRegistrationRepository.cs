using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IRegistrationRepository : IGenericRepository<Registration>
{
    // 1. الفلترة والتصنيف (Status and Date Filters)
    // جلب طلبات التسجيل بناءً على حالتها (قيد الانتظار، مقبول، مرفوض)
    Task<IEnumerable<Registration>> GetRegistrationsByStatusAsync(EduMS.Domain.Enums.RegistrationStatus status, CancellationToken cancellationToken = default);
    
    // جلب طلبات التسجيل المقدمة خلال فترة زمنية محددة
    Task<IEnumerable<Registration>> GetRegistrationsBySubmissionDateAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات التسجيل التابعة لولي أمر محدد
    Task<IEnumerable<Registration>> GetRegistrationsByParentIdAsync(long parentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات التسجيل الموجهة لمدرسة محددة
    Task<IEnumerable<Registration>> GetRegistrationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب طلبات التسجيل لسنة أكاديمية محددة
    Task<IEnumerable<Registration>> GetRegistrationsByAcademicYearIdAsync(long academicYearId, CancellationToken cancellationToken = default);
    
    // جلب طلبات التسجيل التي تم مراجعتها من قبل مستخدم نظام محدد
    Task<IEnumerable<Registration>> GetRegistrationsReviewedByUserAsync(long userId, CancellationToken cancellationToken = default);
}
