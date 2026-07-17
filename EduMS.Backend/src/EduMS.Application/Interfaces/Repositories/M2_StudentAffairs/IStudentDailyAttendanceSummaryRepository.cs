using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentDailyAttendanceSummaryRepository : IGenericRepository<StudentDailyAttendanceSummary>
{
    // 1. الفلترة والتصنيف (Filtering and Thresholds)
    // جلب الملخصات للطلاب الذين تجاوزوا الحد الأقصى للغياب
    Task<IEnumerable<StudentDailyAttendanceSummary>> GetSummariesReachingWarningThresholdAsync(CancellationToken cancellationToken = default);
    
    // جلب الملخصات للطلاب الذين تتجاوز نسبة غيابهم نسبة مئوية معينة
    Task<IEnumerable<StudentDailyAttendanceSummary>> GetSummariesByAbsencePercentageAsync(decimal minimumPercentage, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والزمنية (Foreign Keys & Time)
    // جلب ملخص الغياب التراكمي لطالب محدد
    Task<IEnumerable<StudentDailyAttendanceSummary>> GetSummariesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب ملخص الغياب لطالب في سنة أكاديمية وفصل دراسي محدد
    Task<IEnumerable<StudentDailyAttendanceSummary>> GetSummariesByAcademicTermAsync(long studentId, string academicYear, int semesterNumber, CancellationToken cancellationToken = default);
    
    // جلب إحصائيات الغياب لشهر معين في الفصل الدراسي
    Task<IEnumerable<StudentDailyAttendanceSummary>> GetSummariesByMonthAsync(string academicYear, int monthNumber, CancellationToken cancellationToken = default);
}
