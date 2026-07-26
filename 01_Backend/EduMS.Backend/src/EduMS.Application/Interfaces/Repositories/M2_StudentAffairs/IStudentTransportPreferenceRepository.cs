using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentTransportPreferenceRepository : IGenericRepository<StudentTransportPreference>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التفضيلات بناءً على نوع النقل (حافلة مدرسية، سيارة خاصة، الخ)
    Task<IEnumerable<StudentTransportPreference>> GetPreferencesByTransportTypeAsync(int transportType, CancellationToken cancellationToken = default);
    
    // جلب الطلاب الذين يحتاجون إلى نقل مخصص لذوي الاحتياجات الخاصة
    Task<IEnumerable<StudentTransportPreference>> GetSpecialNeedsTransportPreferencesAsync(CancellationToken cancellationToken = default);
    
    // جلب التفضيلات التي تتطلب وجود مرافق مع الطالب
    Task<IEnumerable<StudentTransportPreference>> GetPreferencesRequiringEscortAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تفضيلات النقل لطالب محدد
    Task<IEnumerable<StudentTransportPreference>> GetPreferencesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الطلاب الذين يفضلون مسار حافلة محدد
    Task<IEnumerable<StudentTransportPreference>> GetPreferencesByBusRouteAsync(long busRouteId, CancellationToken cancellationToken = default);
    
    // جلب التفضيلات المسجلة لسنة أكاديمية معينة
    Task<IEnumerable<StudentTransportPreference>> GetPreferencesByAcademicYearIdAsync(long academicYearId, CancellationToken cancellationToken = default);
}
