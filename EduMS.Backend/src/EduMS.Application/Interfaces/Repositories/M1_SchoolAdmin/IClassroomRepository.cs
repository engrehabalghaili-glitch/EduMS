using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IClassroomRepository : IGenericRepository<Classroom>
{
    // 1. Unique Constraints
    // التحقق من أن كود الفصل غير مكرر داخل نفس المدرسة
    Task<bool> IsClassroomCodeUniqueAsync(long schoolId, string classroomCode, long? excludeId = null);
    
    // 2. Status Filters
    Task<IEnumerable<Classroom>> GetActiveClassroomsAsync(long schoolId);
    
    // 3. Filtering by Grade & Attributes
    // جلب الفصول الدراسية لمدرسة معينة بناءً على الصف الدراسي (GradeLevel)
    Task<IEnumerable<Classroom>> GetClassroomsByGradeLevelAsync(long schoolId, int gradeLevel);
    
    // جلب الفصول الذكية فقط داخل المدرسة
    Task<IEnumerable<Classroom>> GetSmartClassroomsAsync(long schoolId);
    
    // 4. Foreign Keys
    // جلب الفصول التي يكون فيها موظف معين هو رائد الفصل (Homeroom Teacher)
    Task<IEnumerable<Classroom>> GetClassroomsByHomeroomTeacherAsync(long homeroomTeacherEmployeeId);
}

