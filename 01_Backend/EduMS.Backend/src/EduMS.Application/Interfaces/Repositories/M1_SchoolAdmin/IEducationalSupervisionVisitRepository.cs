using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IEducationalSupervisionVisitRepository : IGenericRepository<EducationalSupervisionVisit>
{
    // 1. Filtering by location
    // جلب الزيارات المجدولة لمدرسة معينة
    Task<IEnumerable<EducationalSupervisionVisit>> GetVisitsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الزيارات لمديرية كاملة
    Task<IEnumerable<EducationalSupervisionVisit>> GetVisitsByDirectorateIdAsync(long directorateId, CancellationToken cancellationToken = default);
    
    // 2. Status & Supervisor Filters
    // جلب الزيارات التي قام بها مشرف معين (موظف)
    Task<IEnumerable<EducationalSupervisionVisit>> GetVisitsBySupervisorEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الزيارات حسب الحالة (مجدولة، مكتملة، تحتاج متابعة)
    Task<IEnumerable<EducationalSupervisionVisit>> GetVisitsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // 3. Performance / Evaluation
    // الفلترة بحسب نتيجة التقييم (أكبر من أو يساوي تقييم معين)
    Task<IEnumerable<EducationalSupervisionVisit>> GetVisitsAboveScoreAsync(decimal minimumScore, CancellationToken cancellationToken = default);
}



