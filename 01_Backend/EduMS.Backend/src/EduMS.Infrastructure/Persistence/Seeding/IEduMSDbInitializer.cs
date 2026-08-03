using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.Persistence.Seeding;

/// <summary>
/// واجهة مهندس تهيئة البيانات وبذر البيانات الأساسية في النظام (Master Data Seeding Interface).
/// </summary>
public interface IEduMSDbInitializer
{
    /// <summary>
    /// بذر البيانات الأساسية (الأدوار، الصلاحيات، حساب مدير النظام، المدرسة، المراحل الدراسية، القاعات، وأنواع الرسوم) بشكل آمن ومقاوم للتكرار.
    /// </summary>
    Task SeedAsync(CancellationToken cancellationToken = default);
}
