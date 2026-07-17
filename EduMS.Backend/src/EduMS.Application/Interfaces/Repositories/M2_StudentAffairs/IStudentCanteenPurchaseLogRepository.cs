using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentCanteenPurchaseLogRepository : IGenericRepository<StudentCanteenPurchaseLog>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // البحث عن عملية شراء محددة باستخدام رقم الحوالة/المرجع
    Task<StudentCanteenPurchaseLog?> GetPurchaseByReferenceNumberAsync(string referenceNumber, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب كافة عمليات الشراء التي تمت خلال فترة زمنية محددة
    Task<IEnumerable<StudentCanteenPurchaseLog>> GetPurchasesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب عمليات الشراء بناءً على طريقة الدفع (نقدي، بطاقة الطالب)
    Task<IEnumerable<StudentCanteenPurchaseLog>> GetPurchasesByPaymentMethodAsync(int paymentMethod, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة مشتريات المقصف لطالب محدد
    Task<IEnumerable<StudentCanteenPurchaseLog>> GetPurchasesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب العمليات المرتبطة بعنصر معين من المقصف
    Task<IEnumerable<StudentCanteenPurchaseLog>> GetPurchasesByCanteenItemIdAsync(long canteenItemId, CancellationToken cancellationToken = default);
    
    // جلب عمليات البيع التي أشرف عليها موظف محدد
    Task<IEnumerable<StudentCanteenPurchaseLog>> GetPurchasesServedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
