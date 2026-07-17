using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentPsychologicalCounselingLogRepository : IGenericRepository<StudentPsychologicalCounselingLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الإرشاد النفسي بناءً على حالة الحالة (مفتوحة، قيد المتابعة، مغلقة)
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByStatusAsync(int caseStatus, CancellationToken cancellationToken = default);
    
    // جلب الجلسات بناءً على الفئة (ضغط دراسي، مشكلة سلوكية، صعوبات اجتماعية)
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByCategoryAsync(int sessionCategory, CancellationToken cancellationToken = default);
    
    // جلب الجلسات التي تمت خلال فترة زمنية محددة
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الجلسات التي تتطلب متابعة في فترة زمنية قادمة (للمرشدين)
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByFollowUpDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة السجلات الخاصة بطالب محدد (مع مراعاة السرية إن لزم الأمر)
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الجلسات التي قام بها مرشد نفسي محدد
    Task<IEnumerable<StudentPsychologicalCounselingLog>> GetCounselingLogsByCounselorAsync(long counselorEmployeeId, CancellationToken cancellationToken = default);
}
