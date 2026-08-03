using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolAcademicYearRepository : IGenericRepository<SchoolAcademicYear>
{
    // 1. Unique Constraints
    // التحقق من أن كود العام الدراسي غير مكرر داخل نفس المدرسة
    Task<bool> IsYearCodeUniqueAsync(long schoolId, string yearCode, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Status & Current Year
    // جلب العام الدراسي الحالي للمدرسة
    Task<SchoolAcademicYear?> GetCurrentAcademicYearAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الأعوام الدراسية النشطة
    Task<IEnumerable<SchoolAcademicYear>> GetOpenAcademicYearsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. Date queries
    // جلب العام الدراسي الذي يشمل تاريخاً معيناً
    Task<SchoolAcademicYear?> GetAcademicYearByDateAsync(long schoolId, DateTime date, CancellationToken cancellationToken = default);
}



