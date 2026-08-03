using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IPaymentToInvoiceSettlementRepository : IGenericRepository<PaymentToInvoiceSettlement>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التسويات المتعلقة بإيصال دفع محدد
    Task<IEnumerable<PaymentToInvoiceSettlement>> GetSettlementsByPaymentVoucherIdAsync(long paymentVoucherId, CancellationToken cancellationToken = default);
    
    // جلب التسويات المتعلقة بفاتورة معينة لتتبع الدفعات
    Task<IEnumerable<PaymentToInvoiceSettlement>> GetSettlementsByFeeInvoiceIdAsync(long feeInvoiceId, CancellationToken cancellationToken = default);
    
    // جلب جميع تسويات الدفع الخاصة بطالب محدد
    Task<IEnumerable<PaymentToInvoiceSettlement>> GetSettlementsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}
