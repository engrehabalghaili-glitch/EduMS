using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IFeeInvoiceRepository : IGenericRepository<FeeInvoice>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الفواتير بناءً على حالة الدفع (غير مدفوعة، مدفوعة جزئياً، مدفوعة كلياً)
    Task<IEnumerable<FeeInvoice>> GetInvoicesByStatusAsync(int status, CancellationToken cancellationToken = default);
    
    // جلب الفواتير المتأخرة عن تاريخ الاستحقاق
    Task<IEnumerable<FeeInvoice>> GetOverdueInvoicesAsync(DateTime currentDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الفواتير الخاصة بطالب محدد
    Task<IEnumerable<FeeInvoice>> GetInvoicesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب הפواتير المرتبطة بهيكل رسوم محدد (FeeStructure)
    Task<IEnumerable<FeeInvoice>> GetInvoicesByFeeStructureIdAsync(long feeStructureId, CancellationToken cancellationToken = default);
}
