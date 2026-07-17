using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentActivityParticipationRepository : IGenericRepository<StudentActivityParticipation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأنشطة بناءً على نوع النشاط (رياضي، ثقافي، تطوعي، الخ)
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsByTypeAsync(int activityType, CancellationToken cancellationToken = default);
    
    // جلب الأنشطة التي تمت خلال فترة زمنية محددة
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الأنشطة التي حصل فيها الطلاب على جوائز (ذهبية، فضية، الخ)
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsWithAwardsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة مشاركات الأنشطة الخاصة بطالب محدد
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الأنشطة التي أشرف عليها موظف معين
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsBySupervisorAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب كافة الأنشطة الطلابية المسجلة في مدرسة معينة
    Task<IEnumerable<StudentActivityParticipation>> GetParticipationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
