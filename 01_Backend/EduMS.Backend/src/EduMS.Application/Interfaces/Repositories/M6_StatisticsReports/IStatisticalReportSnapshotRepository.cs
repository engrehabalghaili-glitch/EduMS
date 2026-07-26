using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M6_StatisticsReports;

public interface IStatisticalReportSnapshotRepository : IGenericRepository<StatisticalReportSnapshot>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب لقطات التقارير بناءً على كود التقرير (مثل ANNUAL_COMPREHENSIVE_REPORT)
    Task<IEnumerable<StatisticalReportSnapshot>> GetSnapshotsByReportCodeAsync(string reportCode, CancellationToken cancellationToken = default);
    
    // جلب اللقطات التي تم التحقق منها من قبل المكتب التعليمي
    Task<IEnumerable<StatisticalReportSnapshot>> GetVerifiedSnapshotsAsync(CancellationToken cancellationToken = default);
    
    // جلب اللقطات المأخوذة في تاريخ معين أو فترة معينة
    Task<IEnumerable<StatisticalReportSnapshot>> GetSnapshotsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب اللقطات الإحصائية الخاصة بمدرسة محددة
    Task<IEnumerable<StatisticalReportSnapshot>> GetSnapshotsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب اللقطات المرتبطة بفترة إقفال أكاديمي محددة
    Task<IEnumerable<StatisticalReportSnapshot>> GetSnapshotsByAcademicLockPeriodIdAsync(long academicLockPeriodId, CancellationToken cancellationToken = default);
}
