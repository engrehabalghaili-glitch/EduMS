using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IFeePaymentRepository : IGenericRepository<FeePayment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المدفوعات بناءً على حالتها (معلق، مؤكد، ملغى، الخ)
    Task<IEnumerable<FeePayment>> GetPaymentsByStatusAsync(int paymentStatus, CancellationToken cancellationToken = default);
    
    // جلب المدفوعات في تاريخ أو فترة معينة
    Task<IEnumerable<FeePayment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب المدفوعات التي لم يتم تأكيدها بعد
    Task<IEnumerable<FeePayment>> GetUnconfirmedPaymentsAsync(CancellationToken cancellationToken = default);
    
    // جلب المدفوعات التي تم التراجع عنها (Reversed)
    Task<IEnumerable<FeePayment>> GetReversedPaymentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب مدفوعات طالب محدد
    Task<IEnumerable<FeePayment>> GetPaymentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب مدفوعات حساب مالي محدد
    Task<IEnumerable<FeePayment>> GetPaymentsByStudentAccountIdAsync(long studentAccountId, CancellationToken cancellationToken = default);
    
    // جلب الدفعات المرتبطة بفاتورة معينة
    Task<IEnumerable<FeePayment>> GetPaymentsByInvoiceIdAsync(long invoiceId, CancellationToken cancellationToken = default);
    
    // جلب مدفوعات مدرسة محددة
    Task<IEnumerable<FeePayment>> GetPaymentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
