using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IDirectorateExamCenterAssignmentRepository : IGenericRepository<DirectorateExamCenterAssignment>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود مركز الاختبار
    Task<bool> IsCenterCodeUniqueAsync(long directorateId, string centerCode, long? excludeId = null);
    
    // 2. Center Location & Personnel
    // جلب المراكز الامتحانية التي تستضيفها مدرسة معينة
    Task<IEnumerable<DirectorateExamCenterAssignment>> GetCentersHostedAtSchoolAsync(long schoolId);
    
    // جلب المراكز بناءً على رئيس المركز (Chief Superintendent)
    Task<IEnumerable<DirectorateExamCenterAssignment>> GetCentersBySuperintendentAsync(long employeeId);
    
    // 3. Status Filters
    // جلب المراكز الامتحانية الجارية حالياً
    Task<IEnumerable<DirectorateExamCenterAssignment>> GetActiveExamCentersAsync(long directorateId);
}

