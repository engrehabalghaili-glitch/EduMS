using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IGradeCapacityRepository : IGenericRepository<GradeCapacity>
{
    // 1. Unique Constraints
    // التأكد من عدم تكرار إعدادات الصف لنفس العام الأكاديمي والمرحلة
    Task<bool> IsGradeCapacityUniqueAsync(long academicYearId, long schoolLevelId, string gradeLevelCode, long? excludeId = null);
    
    // 2. Capacity & Enrollment Checks
    // جلب الصفوف التي وصلت للحد الأقصى للاستيعاب
    Task<IEnumerable<GradeCapacity>> GetFullCapacityGradesAsync(long academicYearId);
    
    // التحقق مما إذا كان هناك مقعد متاح لتسجيل طالب جديد
    Task<bool> HasAvailableSeatAsync(long gradeCapacityId);
    
    // 3. Gender Filters
    // جلب سعات الصفوف المخصصة لجنس معين (بنين، بنات، مختلط)
    Task<IEnumerable<GradeCapacity>> GetGradeCapacitiesByGenderAsync(long academicYearId, int genderAllocation);
}

