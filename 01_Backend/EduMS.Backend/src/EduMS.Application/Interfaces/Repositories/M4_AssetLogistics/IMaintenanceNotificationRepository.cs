using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IMaintenanceNotificationRepository : IGenericRepository<MaintenanceNotification>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإشعارات غير المقروءة لمستخدم محدد
    Task<IEnumerable<MaintenanceNotification>> GetUnreadNotificationsAsync(long recipientUserId, CancellationToken cancellationToken = default);
    
    // جلب الإشعارات بناءً على حالة الإشعار (مرسل، مقروء، ملغى)
    Task<IEnumerable<MaintenanceNotification>> GetNotificationsByStatusAsync(int notificationStatus, CancellationToken cancellationToken = default);
    
    // جلب الإشعارات حسب درجة الأهمية (عادي، مهم، عاجل)
    Task<IEnumerable<MaintenanceNotification>> GetNotificationsByPriorityAsync(int priority, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الإشعارات الخاصة بمدرسة محددة
    Task<IEnumerable<MaintenanceNotification>> GetNotificationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب جميع الإشعارات الخاصة بمستخدم/مستلم معين
    Task<IEnumerable<MaintenanceNotification>> GetNotificationsByRecipientAsync(long recipientUserId, CancellationToken cancellationToken = default);
}
