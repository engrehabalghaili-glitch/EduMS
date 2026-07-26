using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeePayrollRepository : IGenericRepository<EmployeePayroll>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب رواتب الموظفين في شهر وسنة محددين
    Task<IEnumerable<EmployeePayroll>> GetPayrollsByMonthAndYearAsync(int month, int year, CancellationToken cancellationToken = default);
    
    // جلب الرواتب بناءً على حالة الدفع (معلق، مدفوع، الخ)
    Task<IEnumerable<EmployeePayroll>> GetPayrollsByPaymentStatusAsync(int paymentStatus, CancellationToken cancellationToken = default);
    
    // جلب الرواتب التي لم تتم مزامنتها مع النظام المالي بعد
    Task<IEnumerable<EmployeePayroll>> GetUnsyncedPayrollsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة كشوفات الرواتب الخاصة بموظف محدد
    Task<IEnumerable<EmployeePayroll>> GetPayrollsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب مسيرات رواتب مدرسة معينة لشهر محدد
    Task<IEnumerable<EmployeePayroll>> GetSchoolPayrollsAsync(long schoolId, int month, int year, CancellationToken cancellationToken = default);
    
    // جلب مسيرات رواتب قطاع أو إدارة محددة
    Task<IEnumerable<EmployeePayroll>> GetSectorPayrollsAsync(long sectorId, int month, int year, CancellationToken cancellationToken = default);
}
