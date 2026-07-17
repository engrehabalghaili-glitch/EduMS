using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentAssignmentSubmissionRepository : IGenericRepository<StudentAssignmentSubmission>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تسليمات الواجبات بناءً على حالة التسليم (مبكر، متأخر، لم يسلم)
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsByStatusAsync(int submissionStatus, CancellationToken cancellationToken = default);
    
    // جلب تسليمات الواجبات خلال فترة زمنية معينة
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الواجبات التي قام بتسليمها طالب محدد
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب تسليمات الواجبات الخاصة بمادة دراسية معينة
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsBySubjectIdAsync(long subjectId, CancellationToken cancellationToken = default);
    
    // جلب تسليمات الواجبات الخاصة بغرفة صفية معينة
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب التسليمات التي تم تقييمها/تصحيحها من قبل معلم محدد
    Task<IEnumerable<StudentAssignmentSubmission>> GetSubmissionsGradedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
