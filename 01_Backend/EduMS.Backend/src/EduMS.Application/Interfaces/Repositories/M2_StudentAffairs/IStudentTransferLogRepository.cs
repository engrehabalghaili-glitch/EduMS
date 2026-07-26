using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentTransferLogRepository : IGenericRepository<StudentTransferLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات النقل بناءً على حالتها (معلق، معتمد، مرفوض)
    Task<IEnumerable<StudentTransferLog>> GetTransferLogsByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل التي تمت خلال فترة زمنية محددة
    Task<IEnumerable<StudentTransferLog>> GetTransferLogsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة طلبات النقل الخاصة بطالب محدد
    Task<IEnumerable<StudentTransferLog>> GetTransferLogsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الصادرة من مدرسة معينة
    Task<IEnumerable<StudentTransferLog>> GetTransfersFromSchoolAsync(long fromSchoolId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الواردة إلى مدرسة معينة
    Task<IEnumerable<StudentTransferLog>> GetTransfersToSchoolAsync(long toSchoolId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل التي تم اعتمادها من قبل موظف محدد
    Task<IEnumerable<StudentTransferLog>> GetTransfersApprovedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
