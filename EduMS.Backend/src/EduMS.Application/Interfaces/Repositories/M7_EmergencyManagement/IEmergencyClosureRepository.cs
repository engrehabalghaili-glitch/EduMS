using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface IEmergencyClosureRepository : IGenericRepository<EmergencyClosure>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإغلاقات بناءً على الحالة (مخطط له، نشط، منتهي)
    Task<IEnumerable<EmergencyClosure>> GetClosuresByStatusAsync(int closureStatus, CancellationToken cancellationToken = default);
    
    // جلب الإغلاقات التي تم تفعيل التعليم البديل فيها
    Task<IEnumerable<EmergencyClosure>> GetClosuresWithAlternativeEducationAsync(CancellationToken cancellationToken = default);
    
    // جلب الإغلاقات التي لم يتم تعويض أيامها بعد
    Task<IEnumerable<EmergencyClosure>> GetUncompensatedClosuresAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الإغلاقات الطارئة الخاصة بمدرسة محددة
    Task<IEnumerable<EmergencyClosure>> GetClosuresBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
