using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IDirectorateRepository : IGenericRepository<Directorate>
{
    // 1. التحقق من عدم التكرار (Unique Constraints)
    Task<bool> IsDirectorateCodeUniqueAsync(string directorateCode, long? excludeId = null);
    
    // 2. الجلب بناءً على الحالة (Status Filters)
    Task<IEnumerable<Directorate>> GetActiveDirectoratesAsync();
    
    // 3. الاستعلام بواسطة حقول تصنيفية (Filtering)
    // جلب جميع المديريات التابعة لمحافظة محددة
    Task<IEnumerable<Directorate>> GetDirectoratesByGovernorateAsync(string governorate);
    
    // 4. استعلامات بحث مخصصة (Custom Search)
    // البحث عن مديرية بالاسم (عربي أو إنجليزي)
    Task<IEnumerable<Directorate>> SearchDirectoratesByNameAsync(string searchTerm);
    
    // البحث بواسطة اسم مدير المديرية
    Task<IEnumerable<Directorate>> SearchByDirectorNameAsync(string directorName);
}

