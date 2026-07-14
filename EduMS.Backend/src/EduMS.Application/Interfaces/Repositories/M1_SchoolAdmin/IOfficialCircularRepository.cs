using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IOfficialCircularRepository : IGenericRepository<OfficialCircular>
{
    // 1. Unique Constraints
    // التحقق من عدم تكرار رقم التعميم
    Task<bool> IsCircularNumberUniqueAsync(string circularNumber, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Audience Filtering
    // جلب التعاميم النشطة والموجهة لجمهور معين (مثلاً: جميع المدارس، معلمون فقط)
    Task<IEnumerable<OfficialCircular>> GetCircularsByAudienceAsync(int targetAudience, CancellationToken cancellationToken = default);
    
    // 3. Acknowledgment Tracking
    // جلب التعاميم التي تتطلب إقراراً بالإطلاع (Mandatory Acknowledgment) والتي اقترب موعدها النهائي
    Task<IEnumerable<OfficialCircular>> GetCircularsPendingAcknowledgmentAsync(DateTime currentThresholdDate, CancellationToken cancellationToken = default);
}



