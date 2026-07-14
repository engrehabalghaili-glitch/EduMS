using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolCurriculumPlanRepository : IGenericRepository<SchoolCurriculumPlan>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود الخطة الدراسية
    Task<bool> IsPlanCodeUniqueAsync(long schoolId, string planCode, long? excludeId = null);
    
    // التحقق من عدم تكرار الخطة لنفس المستوى الدراسي في نفس العام الأكاديمي
    Task<bool> IsPlanUniqueForGradeAndYearAsync(long schoolId, long gradeCapacityId, long academicYearId, long? excludeId = null);
    
    // 2. Status Filters
    // جلب الخطط المعتمدة فقط
    Task<IEnumerable<SchoolCurriculumPlan>> GetApprovedPlansAsync(long schoolId);
    
    // 3. Date queries
    // جلب الخطط الدراسية الفعالة بناءً على تاريخ محدد
    Task<IEnumerable<SchoolCurriculumPlan>> GetEffectivePlansByDateAsync(long schoolId, DateTime date);
}

