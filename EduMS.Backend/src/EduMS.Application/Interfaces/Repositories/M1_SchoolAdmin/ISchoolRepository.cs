using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolRepository : IGenericRepository<School>
{
    // 1. التحقق من عدم التكرار (Unique Constraints)
    // نمرر excludeId لتجاهل المدرسة الحالية عند عملية التعديل (Update)
    Task<bool> IsSchoolCodeUniqueAsync(string schoolCode, long? excludeId = null);
    
    // 2. الجلب بناءً على الحالة (Status Filters)
    // جلب المدارس الفعالة فقط
    Task<IEnumerable<School>> GetActiveSchoolsAsync();
    
    // 3. الاستعلام بواسطة المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع المدارس التابعة لمديرية تعليمية محددة
    Task<IEnumerable<School>> GetSchoolsByDirectorateIdAsync(long directorateId);
    
    // جلب جميع المدارس التابعة لمرحلة تعليمية محددة
    Task<IEnumerable<School>> GetSchoolsByEducationalStageIdAsync(long educationalStageId);
    
    // 4. استعلامات بحث مخصصة (Custom Search)
    // البحث عن مدرسة بالاسم (عربي أو إنجليزي)
    Task<IEnumerable<School>> SearchSchoolsByNameAsync(string searchTerm);
}

