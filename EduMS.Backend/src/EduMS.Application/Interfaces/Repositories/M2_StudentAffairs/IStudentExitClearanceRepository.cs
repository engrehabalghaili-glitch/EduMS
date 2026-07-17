using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentExitClearanceRepository : IGenericRepository<StudentExitClearance>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار الرقم المرجعي لإخلاء الطرف
    Task<bool> IsClearanceReferenceNumberUniqueAsync(string referenceNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات إخلاء الطرف بناءً على حالتها (قيد التدقيق، معتمد، مرفوض بسبب التزامات)
    Task<IEnumerable<StudentExitClearance>> GetClearancesByStatusAsync(int clearanceStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات إخلاء الطرف بناءً على سبب الإخلاء (تخرج، نقل، انسحاب)
    Task<IEnumerable<StudentExitClearance>> GetClearancesByReasonAsync(int clearanceReason, CancellationToken cancellationToken = default);
    
    // جلب طلبات إخلاء الطرف التي تم إنشاؤها خلال فترة محددة
    Task<IEnumerable<StudentExitClearance>> GetClearancesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة طلبات إخلاء الطرف المرتبطة بطالب محدد
    Task<IEnumerable<StudentExitClearance>> GetClearancesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات إخلاء الطرف التي اعتمدها مدير/موظف محدد
    Task<IEnumerable<StudentExitClearance>> GetClearancesApprovedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
