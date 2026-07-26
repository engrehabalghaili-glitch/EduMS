using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب البنود غير المدفوعة أو المتأخرة
    Task<IEnumerable<InvoiceItem>> GetUnpaidItemsAsync(CancellationToken cancellationToken = default);
    
    // جلب البنود المعفاة من الدفع (Waived)
    Task<IEnumerable<InvoiceItem>> GetWaivedItemsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تفاصيل أو بنود فاتورة محددة
    Task<IEnumerable<InvoiceItem>> GetItemsByInvoiceIdAsync(long invoiceId, CancellationToken cancellationToken = default);
    
    // جلب البنود المرتبطة بنوع رسوم محدد (FeeType)
    Task<IEnumerable<InvoiceItem>> GetItemsByFeeTypeIdAsync(long feeTypeId, CancellationToken cancellationToken = default);
}
