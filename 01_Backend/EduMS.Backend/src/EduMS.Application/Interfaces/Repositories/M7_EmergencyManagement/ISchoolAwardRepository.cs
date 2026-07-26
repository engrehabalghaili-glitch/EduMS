using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M7_EmergencyManagement;

public interface ISchoolAwardRepository : IGenericRepository<SchoolAward>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الجوائز بناءً على مستوى الجائزة (محلي، وطني، إقليمي، دولي)
    Task<IEnumerable<SchoolAward>> GetAwardsByLevelAsync(int awardLevel, CancellationToken cancellationToken = default);
    
    // جلب الجوائز بناءً على التصنيف (تعليمي، رياضي، ثقافي، الخ)
    Task<IEnumerable<SchoolAward>> GetAwardsByCategoryAsync(string awardCategory, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الجوائز الحاصلة عليها مدرسة محددة
    Task<IEnumerable<SchoolAward>> GetAwardsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
