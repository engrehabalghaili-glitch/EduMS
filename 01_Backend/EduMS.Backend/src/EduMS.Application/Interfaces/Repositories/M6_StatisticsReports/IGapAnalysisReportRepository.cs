using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IGapAnalysisReportRepository : IGenericRepository<GapAnalysisReport>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تقارير الفجوة بناءً على نوع التحليل (طلاب-معلمين، طلاب-فصول، الخ)
    Task<IEnumerable<GapAnalysisReport>> GetReportsByAnalysisTypeAsync(string analysisType, CancellationToken cancellationToken = default);
    
    // جلب التقارير التي بها فجوة سلبية (Deficit) وتحتاج لتدخل
    Task<IEnumerable<GapAnalysisReport>> GetDeficitGapReportsAsync(CancellationToken cancellationToken = default);
    
    // جلب تقارير الفجوة ذات الأولوية العالية (Priority = 1)
    Task<IEnumerable<GapAnalysisReport>> GetHighPriorityReportsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تحليلات الفجوة الخاصة بمدرسة محددة
    Task<IEnumerable<GapAnalysisReport>> GetReportsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
