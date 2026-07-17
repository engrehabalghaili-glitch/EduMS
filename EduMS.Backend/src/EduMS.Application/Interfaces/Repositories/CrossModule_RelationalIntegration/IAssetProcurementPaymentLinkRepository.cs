using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IAssetProcurementPaymentLinkRepository : IGenericRepository<AssetProcurementPaymentLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الدفعات المرتبطة بأمر شراء محدد
    Task<IEnumerable<AssetProcurementPaymentLink>> GetLinksByPurchaseOrderIdAsync(long purchaseOrderId, CancellationToken cancellationToken = default);
    
    // جلب أوامر الشراء المرتبطة بسند صرف محدد
    Task<IEnumerable<AssetProcurementPaymentLink>> GetLinksByPaymentVoucherIdAsync(long paymentVoucherId, CancellationToken cancellationToken = default);
    
    // جلب الروابط الخاصة بمدرسة محددة
    Task<IEnumerable<AssetProcurementPaymentLink>> GetLinksBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
