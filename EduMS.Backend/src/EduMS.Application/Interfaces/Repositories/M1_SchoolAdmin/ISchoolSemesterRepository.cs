using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolSemesterRepository : IGenericRepository<SchoolSemester>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار رقم الفصل الدراسي داخل نفس العام الأكاديمي
    Task<bool> IsSemesterNumberUniqueAsync(long academicYearId, int semesterNumber, long? excludeId = null);
    
    // 2. Status & Current Semester
    // جلب الفصل الدراسي الحالي للعام الأكاديمي
    Task<SchoolSemester?> GetCurrentSemesterAsync(long academicYearId);
    
    // جلب الفصول الدراسية التابعة لعام أكاديمي محدد
    Task<IEnumerable<SchoolSemester>> GetSemestersByAcademicYearIdAsync(long academicYearId);
    
    // 3. Date queries
    // جلب الفصل الدراسي الذي يقع فيه تاريخ معين
    Task<SchoolSemester?> GetSemesterByDateAsync(long academicYearId, DateTime date);
}

