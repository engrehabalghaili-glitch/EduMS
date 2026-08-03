using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentHealthRecordRepository : IGenericRepository<StudentHealthRecord>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار كود السجل الصحي
    Task<bool> IsHealthRecordCodeUniqueAsync(string recordCode, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب السجلات الصحية بناءً على الحالة الصحية (مستقر، يحتاج مراقبة، حرج)
    Task<IEnumerable<StudentHealthRecord>> GetRecordsByHealthStatusAsync(int healthStatus, CancellationToken cancellationToken = default);
    
    // جلب السجلات الصحية للطلاب غير اللائقين للتربية البدنية
    Task<IEnumerable<StudentHealthRecord>> GetUnfitForPhysicalEducationRecordsAsync(CancellationToken cancellationToken = default);
    
    // جلب السجلات الصحية التي تتطلب فحصاً قادماً في فترة معينة
    Task<IEnumerable<StudentHealthRecord>> GetRecordsByNextCheckupDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة السجلات الصحية الخاصة بطالب محدد
    Task<IEnumerable<StudentHealthRecord>> GetRecordsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}
