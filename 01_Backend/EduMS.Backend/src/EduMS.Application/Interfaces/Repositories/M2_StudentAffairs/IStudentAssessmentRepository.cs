using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentAssessmentRepository : IGenericRepository<StudentAssessment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التقييمات بناءً على الفئة (شهري، نصفي، نهائي، مشروع)
    Task<IEnumerable<StudentAssessment>> GetAssessmentsByCategoryAsync(int assessmentCategory, CancellationToken cancellationToken = default);
    
    // جلب التقييمات التي تمت خلال فترة زمنية محددة
    Task<IEnumerable<StudentAssessment>> GetAssessmentsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب التقييمات التي تعتبر امتحانات إعادة (دور ثاني/إعادة)
    Task<IEnumerable<StudentAssessment>> GetRetakeAssessmentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة التقييمات الخاصة بطالب محدد
    Task<IEnumerable<StudentAssessment>> GetAssessmentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب التقييمات الخاصة بمادة دراسية محددة
    Task<IEnumerable<StudentAssessment>> GetAssessmentsBySubjectIdAsync(long subjectId, CancellationToken cancellationToken = default);
    
    // جلب كافة التقييمات التي تمت في غرفة صفية محددة
    Task<IEnumerable<StudentAssessment>> GetAssessmentsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب التقييمات التي قام بتقييمها موظف/معلم محدد
    Task<IEnumerable<StudentAssessment>> GetAssessmentsEvaluatedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
