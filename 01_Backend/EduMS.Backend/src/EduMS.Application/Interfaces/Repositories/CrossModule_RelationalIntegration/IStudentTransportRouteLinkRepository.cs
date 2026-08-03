using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IStudentTransportRouteLinkRepository : IGenericRepository<StudentTransportRouteLink>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الروابط الفعالة لاشتراكات النقل
    Task<IEnumerable<StudentTransportRouteLink>> GetActiveLinksAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الروابط المرتبطة باشتراك طالب محدد (Subscription)
    Task<IEnumerable<StudentTransportRouteLink>> GetLinksBySubscriptionIdAsync(long studentTransportationSubscriptionId, CancellationToken cancellationToken = default);
    
    // جلب جميع اشتراكات الطلاب على خط نقل محدد (Route/Service)
    Task<IEnumerable<StudentTransportRouteLink>> GetLinksByTransportationServiceIdAsync(long transportationServiceId, CancellationToken cancellationToken = default);
    
    // جلب تفاصيل نقل طالب محدد
    Task<IEnumerable<StudentTransportRouteLink>> GetLinksByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}
