using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentTransportationSubscriptionRepository : IGenericRepository<StudentTransportationSubscription>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب اشتراكات النقل بناءً على حالة الاشتراك (نشط، معلق، ملغي)
    Task<IEnumerable<StudentTransportationSubscription>> GetSubscriptionsByStatusAsync(int subscriptionStatus, CancellationToken cancellationToken = default);
    
    // جلب الاشتراكات بناءً على نوعها (ذهاب وعودة، صباحي فقط، مسائي فقط)
    Task<IEnumerable<StudentTransportationSubscription>> GetSubscriptionsByTypeAsync(int subscriptionType, CancellationToken cancellationToken = default);
    
    // جلب الاشتراكات الفعالة التي تقع ضمن فترة زمنية محددة
    Task<IEnumerable<StudentTransportationSubscription>> GetActiveSubscriptionsByDateRangeAsync(DateTime checkDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب اشتراكات النقل لطالب محدد
    Task<IEnumerable<StudentTransportationSubscription>> GetSubscriptionsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب كافة الاشتراكات المرتبطة بمسار حافلة محدد
    Task<IEnumerable<StudentTransportationSubscription>> GetSubscriptionsByRouteIdAsync(long routeId, CancellationToken cancellationToken = default);
}
