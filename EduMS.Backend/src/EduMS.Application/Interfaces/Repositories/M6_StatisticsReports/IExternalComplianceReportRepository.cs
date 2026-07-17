using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IExternalComplianceReportRepository : IGenericRepository<ExternalComplianceReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تقارير الامتثال بناءً على الجهة المستهدفة (وزارة، مكتب تعليم، الخ)
    Task<IEnumerable<ExternalComplianceReport>> GetReportsByTargetEntityAsync(string targetEntityName, CancellationToken cancellationToken = default);
    
    // جلب تقارير الامتثال بناءً على حالة التسليم (في طور الإعداد، مرسل، مستلم، الخ)
    Task<IEnumerable<ExternalComplianceReport>> GetReportsBySubmissionStatusAsync(int submissionStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تقارير الامتثال الخاصة بمدرسة محددة
    Task<IEnumerable<ExternalComplianceReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
