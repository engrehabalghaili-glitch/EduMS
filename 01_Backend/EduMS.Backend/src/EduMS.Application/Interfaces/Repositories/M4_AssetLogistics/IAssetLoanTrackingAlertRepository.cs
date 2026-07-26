using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetLoanTrackingAlertRepository : IGenericRepository<AssetLoanTrackingAlert>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التنبيهات التي لم يتم إرسالها بعد
    Task<IEnumerable<AssetLoanTrackingAlert>> GetUnsentAlertsAsync(CancellationToken cancellationToken = default);
    
    // جلب التنبيهات التي لم يتم الإقرار بها (Acknowledged) من قبل المستلم
    Task<IEnumerable<AssetLoanTrackingAlert>> GetUnacknowledgedAlertsAsync(CancellationToken cancellationToken = default);
    
    // جلب التنبيهات بناءً على نوعها (تذكير، إشعار تأخير، تنبيه غرامة)
    Task<IEnumerable<AssetLoanTrackingAlert>> GetAlertsByTypeAsync(int alertType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التنبيهات المرتبطة بإعارة محددة
    Task<IEnumerable<AssetLoanTrackingAlert>> GetAlertsByLoanIdAsync(long loanId, CancellationToken cancellationToken = default);
    
    // جلب التنبيهات الخاصة بمدرسة محددة
    Task<IEnumerable<AssetLoanTrackingAlert>> GetAlertsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
