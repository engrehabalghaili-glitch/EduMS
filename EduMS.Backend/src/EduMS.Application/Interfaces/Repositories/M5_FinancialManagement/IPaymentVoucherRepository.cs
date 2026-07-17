using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IPaymentVoucherRepository : IGenericRepository<PaymentVoucher>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سندات الدفع التي تمت في فترة معينة
    Task<IEnumerable<PaymentVoucher>> GetVouchersByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب سندات الدفع بناءً على طريقة الدفع (نقدي، تحويل بنكي، شيك)
    Task<IEnumerable<PaymentVoucher>> GetVouchersByPaymentMethodAsync(string paymentMethod, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سندات الدفع الخاصة بمدرسة معينة
    Task<IEnumerable<PaymentVoucher>> GetVouchersBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب السندات المدفوعة لمورد محدد
    Task<IEnumerable<PaymentVoucher>> GetVouchersByVendorIdAsync(long vendorId, CancellationToken cancellationToken = default);
    
    // جلب السندات المرتبطة بحساب نقدي/بنكي معين
    Task<IEnumerable<PaymentVoucher>> GetVouchersByAccountIdAsync(long accountId, CancellationToken cancellationToken = default);
}
