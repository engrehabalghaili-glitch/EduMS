using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أوامر الشراء بناءً على حالتها (مسودة، معتمد، قيد التنفيذ، مستلم كلياً، الخ)
    Task<IEnumerable<PurchaseOrder>> GetOrdersByStatusAsync(int poStatus, CancellationToken cancellationToken = default);
    
    // جلب أوامر الشراء التي تجاوزت موعد التسليم النهائي (متأخرة)
    Task<IEnumerable<PurchaseOrder>> GetOverdueOrdersAsync(DateTime currentDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب أوامر الشراء الخاصة بمدرسة معينة
    Task<IEnumerable<PurchaseOrder>> GetOrdersBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب أمر الشراء المرتبط بطلب احتياج محدد
    Task<PurchaseOrder?> GetOrderByRequirementRequestIdAsync(long requirementRequestId, CancellationToken cancellationToken = default);
}
