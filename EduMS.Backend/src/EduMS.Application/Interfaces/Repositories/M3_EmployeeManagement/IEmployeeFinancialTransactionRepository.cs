using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeFinancialTransactionRepository : IGenericRepository<EmployeeFinancialTransaction>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الحركات المالية بناءً على النوع (سلفة، بدل سفر، مطالبة طبية، الخ)
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsByTypeAsync(int transactionType, CancellationToken cancellationToken = default);
    
    // جلب الحركات بناءً على حالة الاعتماد (مسودة، معتمد من الموارد، مصروف، الخ)
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsByApprovalStatusAsync(int approvalStatus, CancellationToken cancellationToken = default);
    
    // جلب الحركات المالية خلال فترة زمنية محددة
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الحركات المالية الخاصة بموظف محدد
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الحركات التابعة لمدرسة محددة
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الحركات المالية التي اعتمدها موظف/مدير محدد
    Task<IEnumerable<EmployeeFinancialTransaction>> GetTransactionsApprovedByEmployeeAsync(long approvedByEmployeeId, CancellationToken cancellationToken = default);
}
