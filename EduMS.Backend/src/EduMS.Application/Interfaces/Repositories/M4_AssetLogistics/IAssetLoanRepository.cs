using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetLoanRepository : IGenericRepository<AssetLoan>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الإعارات النشطة
    Task<IEnumerable<AssetLoan>> GetActiveLoansAsync(CancellationToken cancellationToken = default);
    
    // جلب الإعارات المتأخرة 
    Task<IEnumerable<AssetLoan>> GetOverdueLoansAsync(CancellationToken cancellationToken = default);
    
    // جلب الإعارات التي عليها غرامات غير مدفوعة
    Task<IEnumerable<AssetLoan>> GetLoansWithUnpaidFinesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب إعارات أصل محدد
    Task<IEnumerable<AssetLoan>> GetLoansByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
    
    // جلب إعارات مستعير محدد (طالب، موظف، جهة خارجية)
    Task<IEnumerable<AssetLoan>> GetLoansByBorrowerAsync(int borrowerType, long borrowerId, CancellationToken cancellationToken = default);
    
    // جلب الإعارات الخاصة بمدرسة محددة
    Task<IEnumerable<AssetLoan>> GetLoansBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
