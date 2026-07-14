using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolShiftRepository : IGenericRepository<SchoolShift>
{
    // 1. Unique Constraints
    // التحقق من أن كود الدوام (فترة الصباح/المساء) غير مكرر
    Task<bool> IsShiftCodeUniqueAsync(long schoolId, string shiftCode, long? excludeId = null);
    
    // 2. Status Filters
    // جلب فترات الدوام الفعالة للمدرسة
    Task<IEnumerable<SchoolShift>> GetActiveShiftsAsync(long schoolId);
    
    // 3. Time Queries
    // معرفة الدوام بناءً على وقت معين (لمعرفة في أي فترة يقع هذا الوقت)
    Task<SchoolShift?> GetShiftByTimeAsync(long schoolId, string timeString);
}

