using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IStudentInvoiceRepository : IGenericRepository<StudentInvoice>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الفواتير بناءً على حالة الدفع (غير مدفوعة، مدفوعة جزئياً، مدفوعة كلياً)
    Task<IEnumerable<StudentInvoice>> GetInvoicesByPaymentStatusAsync(int paymentStatus, CancellationToken cancellationToken = default);
    
    // جلب الفواتير بناءً على حالة الفاتورة (مصدرة، معتمدة، ملغاة، الخ)
    Task<IEnumerable<StudentInvoice>> GetInvoicesByStatusAsync(int invoiceStatus, CancellationToken cancellationToken = default);
    
    // جلب الفواتير المتأخرة
    Task<IEnumerable<StudentInvoice>> GetOverdueInvoicesAsync(DateTime currentDate, CancellationToken cancellationToken = default);
    
    // جلب الفواتير التي بانتظار موافقة ولي الأمر
    Task<IEnumerable<StudentInvoice>> GetInvoicesPendingParentApprovalAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع فواتير طالب محدد
    Task<IEnumerable<StudentInvoice>> GetInvoicesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب جميع فواتير حساب مالي محدد
    Task<IEnumerable<StudentInvoice>> GetInvoicesByStudentAccountIdAsync(long studentAccountId, CancellationToken cancellationToken = default);
    
    // جلب الفواتير الخاصة بمدرسة معينة
    Task<IEnumerable<StudentInvoice>> GetInvoicesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
