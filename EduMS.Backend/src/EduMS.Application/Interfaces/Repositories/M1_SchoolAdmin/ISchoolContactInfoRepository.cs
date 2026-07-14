using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ISchoolContactInfoRepository : IGenericRepository<SchoolContactInfo>
{
    // 1. One-to-One Retrieval
    // جلب بيانات التواصل الخاصة بمدرسة معينة (باعتبارها علاقة One-to-One في الغالب)
    Task<SchoolContactInfo?> GetContactInfoBySchoolIdAsync(long schoolId);
    
    // 2. Search
    // البحث عن المدارس التي تقع في مدينة أو حي معين
    Task<IEnumerable<SchoolContactInfo>> GetSchoolsByLocationAsync(string? city, string? districtName);
}
