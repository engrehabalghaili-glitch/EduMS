using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentComplaintLogRepository : IGenericRepository<StudentComplaintLog>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التحقق من عدم تكرار الرقم المرجعي للشكوى
    Task<bool> IsComplaintReferenceNumberUniqueAsync(string referenceNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الشكاوى التي تم تقديمها خلال فترة معينة
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الشكاوى بناءً على حالتها (مقدمة، قيد التحقيق، مغلقة)
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsByStatusAsync(int complaintStatus, CancellationToken cancellationToken = default);
    
    // جلب الشكاوى بناءً على تصنيفها (أكاديمي، سلوكي، مالي)
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsByCategoryAsync(int complaintCategory, CancellationToken cancellationToken = default);
    
    // جلب كافة الشكاوى التي تم تصعيدها للإدارة التعليمية العليا
    Task<IEnumerable<StudentComplaintLog>> GetEscalatedComplaintsAsync(CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الشكاوى المتعلقة بطالب محدد
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الشكاوى التي قدمها ولي أمر محدد
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsSubmittedByGuardianAsync(long guardianId, CancellationToken cancellationToken = default);
    
    // جلب الشكاوى المسندة لموظف معين ليقوم بالتحقيق فيها
    Task<IEnumerable<StudentComplaintLog>> GetComplaintsAssignedToEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
