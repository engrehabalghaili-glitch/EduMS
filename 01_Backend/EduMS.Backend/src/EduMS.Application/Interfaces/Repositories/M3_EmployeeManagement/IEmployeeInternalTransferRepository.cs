using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeInternalTransferRepository : IGenericRepository<EmployeeInternalTransfer>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات النقل الداخلي بناءً على حالة الموافقة (معلق، معتمد، مرفوض)
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الداخلي المرفوعة خلال فترة زمنية محددة
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة طلبات النقل الخاصة بموظف محدد
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الصادرة من قسم معين
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersFromDepartmentAsync(long fromDepartmentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الواردة إلى قسم معين
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersToDepartmentAsync(long toDepartmentId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات الخاصة بمدرسة محددة
    Task<IEnumerable<EmployeeInternalTransfer>> GetTransfersBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
