using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetMaintenanceTicketRepository : IGenericRepository<AssetMaintenanceTicket>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب البلاغات بناءً على حالة البلاغ (مفتوح، قيد التنفيذ، مكتمل، الخ)
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsByStatusAsync(int ticketStatus, CancellationToken cancellationToken = default);
    
    // جلب البلاغات بناءً على مستوى الخطورة (عادي، متوسط، عالي، طارئ)
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsBySeverityAsync(int severityLevel, CancellationToken cancellationToken = default);
    
    // جلب البلاغات المرفوعة في فترة زمنية معينة
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب بلاغات الصيانة لأصل محدد
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب البلاغات الخاصة بمدرسة محددة
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب البلاغات التي رفعها موظف محدد
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsReportedByUserAsync(long reportedByUserId, CancellationToken cancellationToken = default);
    
    // جلب البلاغات المسندة لفني صيانة محدد
    Task<IEnumerable<AssetMaintenanceTicket>> GetTicketsAssignedToAsync(long assignedToEmployeeId, CancellationToken cancellationToken = default);
}
