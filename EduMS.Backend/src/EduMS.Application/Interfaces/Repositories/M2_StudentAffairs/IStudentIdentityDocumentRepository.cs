using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentIdentityDocumentRepository : IGenericRepository<StudentIdentityDocument>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار رقم الوثيقة (مثل رقم الهوية الوطنية) لنفس نوع الوثيقة
    Task<bool> IsDocumentNumberUniqueAsync(string documentNumber, int documentType, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب وثائق الهوية بناءً على نوع الوثيقة (هوية وطنية، جواز سفر، شهادة ميلاد)
    Task<IEnumerable<StudentIdentityDocument>> GetDocumentsByTypeAsync(int documentType, CancellationToken cancellationToken = default);
    
    // جلب الوثائق بناءً على حالتها (صالحة، منتهية، قيد المراجعة)
    Task<IEnumerable<StudentIdentityDocument>> GetDocumentsByStatusAsync(int documentStatus, CancellationToken cancellationToken = default);
    
    // جلب الوثائق التي لم يتم التحقق منها بعد
    Task<IEnumerable<StudentIdentityDocument>> GetUnverifiedDocumentsAsync(CancellationToken cancellationToken = default);
    
    // جلب الوثائق التي تنتهي صلاحيتها خلال فترة معينة (للتنبيه)
    Task<IEnumerable<StudentIdentityDocument>> GetDocumentsExpiringBeforeAsync(DateTime expiryDateLimit, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة وثائق الهوية الخاصة بطالب محدد
    Task<IEnumerable<StudentIdentityDocument>> GetDocumentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الوثائق التي قام بالتحقق منها موظف معين
    Task<IEnumerable<StudentIdentityDocument>> GetDocumentsVerifiedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
