using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IPersonRepository : IGenericRepository<Person>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار الرقم الوطني/الهوية
    Task<bool> IsNationalIdUniqueAsync(string nationalId, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // التأكد من عدم تكرار البريد الإلكتروني
    Task<bool> IsEmailAddressUniqueAsync(string emailAddress, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // التأكد من عدم تكرار رقم الجواز (إن وجد)
    Task<bool> IsPassportNumberUniqueAsync(string passportNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الأشخاص بناءً على الجنس (ذكر، أنثى)
    Task<IEnumerable<Person>> GetPersonsByGenderAsync(EduMS.Domain.Enums.Gender gender, CancellationToken cancellationToken = default);
    
    // جلب الأشخاص بناءً على حالة الحساب (نشط، غير نشط)
    Task<IEnumerable<Person>> GetActivePersonsAsync(bool isActive, CancellationToken cancellationToken = default);
    
    // 3. البحث المتقدم (Advanced Search)
    // البحث عن شخص باستخدام اسمه (عربي أو إنجليزي)، أو رقم الهوية، أو رقم الجوال
    Task<IEnumerable<Person>> SearchPersonsAsync(string searchTerm, CancellationToken cancellationToken = default);
}
