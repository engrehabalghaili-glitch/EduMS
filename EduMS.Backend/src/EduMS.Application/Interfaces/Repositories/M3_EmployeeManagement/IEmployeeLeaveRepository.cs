using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeLeaveRepository : IGenericRepository<EmployeeLeave>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإجازات بناءً على نوعها (سنوية، مرضية، طارئة، الخ)
    Task<IEnumerable<EmployeeLeave>> GetLeavesByTypeAsync(int leaveType, CancellationToken cancellationToken = default);
    
    // جلب الإجازات بناءً على حالة الموافقة (معلق، معتمد، مرفوض)
    Task<IEnumerable<EmployeeLeave>> GetLeavesByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب الإجازات التي تقع في فترة زمنية محددة
    Task<IEnumerable<EmployeeLeave>> GetLeavesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب إجازات الطوارئ
    Task<IEnumerable<EmployeeLeave>> GetEmergencyLeavesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الإجازات الخاصة بموظف محدد
    Task<IEnumerable<EmployeeLeave>> GetLeavesByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب إجازات الموظفين الخاصة بمدرسة معينة
    Task<IEnumerable<EmployeeLeave>> GetLeavesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
