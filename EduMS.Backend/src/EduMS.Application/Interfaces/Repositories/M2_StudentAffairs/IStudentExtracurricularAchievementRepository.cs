using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentExtracurricularAchievementRepository : IGenericRepository<StudentExtracurricularAchievement>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإنجازات اللامنهجية بناءً على مستوى المنافسة (مدرسي، وطني، دولي)
    Task<IEnumerable<StudentExtracurricularAchievement>> GetAchievementsByCompetitionLevelAsync(int competitionLevel, CancellationToken cancellationToken = default);
    
    // جلب الإنجازات التي تحققت خلال فترة زمنية محددة
    Task<IEnumerable<StudentExtracurricularAchievement>> GetAchievementsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الإنجازات بناءً على المركز أو الميدالية (ذهبية، فضية، مركز أول)
    Task<IEnumerable<StudentExtracurricularAchievement>> GetAchievementsByRankAsync(int rankOrMedal, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الإنجازات والمشاركات الخاصة بطالب محدد
    Task<IEnumerable<StudentExtracurricularAchievement>> GetAchievementsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الإنجازات التي تمت تحت إشراف مدرب/موظف محدد
    Task<IEnumerable<StudentExtracurricularAchievement>> GetAchievementsByCoachAsync(long coachEmployeeId, CancellationToken cancellationToken = default);
}
