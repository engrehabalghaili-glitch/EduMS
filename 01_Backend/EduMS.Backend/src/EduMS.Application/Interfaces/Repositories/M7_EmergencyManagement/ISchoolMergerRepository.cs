using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ISchoolMergerRepository : IGenericRepository<SchoolMerger>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب عمليات الدمج بناءً على حالتها (مخطط، قيد التنفيذ، مكتمل)
    Task<IEnumerable<SchoolMerger>> GetMergersByStatusAsync(int mergerStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب عمليات الدمج التي تكون المدرسة المحددة هي المدرسة المستهدفة (التي تم الدمج إليها)
    Task<IEnumerable<SchoolMerger>> GetMergersByTargetSchoolIdAsync(long targetSchoolId, CancellationToken cancellationToken = default);
}
