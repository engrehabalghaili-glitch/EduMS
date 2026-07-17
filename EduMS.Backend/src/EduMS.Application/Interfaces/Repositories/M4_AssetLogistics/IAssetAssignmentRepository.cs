using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetAssignmentRepository : IGenericRepository<AssetAssignment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التخصيصات النشطة
    Task<IEnumerable<AssetAssignment>> GetActiveAssignmentsAsync(CancellationToken cancellationToken = default);
    
    // جلب التخصيصات المتأخرة عن الإرجاع
    Task<IEnumerable<AssetAssignment>> GetOverdueAssignmentsAsync(DateTime currentDate, CancellationToken cancellationToken = default);
    
    // جلب التخصيصات التي عليها غرامات مالية
    Task<IEnumerable<AssetAssignment>> GetAssignmentsWithPenaltiesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تخصيصات أصل محدد
    Task<IEnumerable<AssetAssignment>> GetAssignmentsByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب التخصيصات بناءً على نوع المستلم (موظف، طالب، قسم، معمل) ومعرفه
    Task<IEnumerable<AssetAssignment>> GetAssignmentsByAssigneeAsync(int assigneeType, long assigneeId, CancellationToken cancellationToken = default);
    
    // جلب التخصيصات الخاصة بمدرسة محددة
    Task<IEnumerable<AssetAssignment>> GetAssignmentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
