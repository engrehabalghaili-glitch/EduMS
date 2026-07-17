using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeExternalTransferRepository : IGenericRepository<EmployeeExternalTransfer>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات النقل الخارجي بناءً على حالة الموافقة (معلق، معتمد، مرفوض، منفذ)
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل بناءً على الاتجاه (صادر من جهة، وارد إلى جهة)
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersByDirectionAsync(int transferDirection, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات النقل الخاصة بموظف محدد
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الصادرة من مدرسة معينة
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersFromSchoolAsync(long fromSchoolId, CancellationToken cancellationToken = default);
    
    // جلب طلبات النقل الواردة إلى مدرسة معينة
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersToSchoolAsync(long toSchoolId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي اعتمدها مستخدم/مدير محدد
    Task<IEnumerable<EmployeeExternalTransfer>> GetTransfersApprovedByUserAsync(long approvedByUserId, CancellationToken cancellationToken = default);
}
