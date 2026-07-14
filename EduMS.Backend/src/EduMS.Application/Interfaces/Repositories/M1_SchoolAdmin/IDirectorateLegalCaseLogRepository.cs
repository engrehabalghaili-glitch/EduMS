using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IDirectorateLegalCaseLogRepository : IGenericRepository<DirectorateLegalCaseLog>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار كود أو رقم القضية
    Task<bool> IsCaseCodeUniqueAsync(long directorateId, string caseCodeNumber, long? excludeId = null);
    
    // 2. Case Filtering
    // جلب القضايا حسب تصنيفها (خلاف قانوني، شكوى إدارية، استفسار تنظيمي)
    Task<IEnumerable<DirectorateLegalCaseLog>> GetCasesByCategoryAsync(long directorateId, int category);
    
    // جلب القضايا حسب حالتها (قيد التحقيق، في المحكمة، مغلقة)
    Task<IEnumerable<DirectorateLegalCaseLog>> GetCasesByStatusAsync(long directorateId, int status);
    
    // 3. Personnel
    // جلب القضايا الموكلة لمستشار قانوني محدد
    Task<IEnumerable<DirectorateLegalCaseLog>> GetCasesByLegalCounselAsync(long employeeId);
}

