using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IFeeInstallmentRepository : IGenericRepository<FeeInstallment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأقساط غير المدفوعة أو المعلقة
    Task<IEnumerable<FeeInstallment>> GetPendingInstallmentsAsync(CancellationToken cancellationToken = default);
    
    // جلب الأقساط المتأخرة
    Task<IEnumerable<FeeInstallment>> GetOverdueInstallmentsAsync(DateTime currentDate, CancellationToken cancellationToken = default);
    
    // جلب الأقساط التي تم إعادة جدولتها (Rescheduled)
    Task<IEnumerable<FeeInstallment>> GetRescheduledInstallmentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب أقساط فاتورة محددة
    Task<IEnumerable<FeeInstallment>> GetInstallmentsByInvoiceIdAsync(long invoiceId, CancellationToken cancellationToken = default);
    
    // جلب أقساط طالب محدد
    Task<IEnumerable<FeeInstallment>> GetInstallmentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب أقساط حساب مالي محدد
    Task<IEnumerable<FeeInstallment>> GetInstallmentsByStudentAccountIdAsync(long studentAccountId, CancellationToken cancellationToken = default);
}
