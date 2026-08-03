using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IVisitorEntryLogRepository : IGenericRepository<VisitorEntryLog>
{
    // 1. Current Visitors
    // جلب الزوار المتواجدين حالياً داخل الحرم المدرسي (لم يسجلوا خروجاً بعد)
    Task<IEnumerable<VisitorEntryLog>> GetActiveVisitorsAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 2. Search & History
    // البحث عن زائر برقم الهوية أو جواز السفر
    Task<IEnumerable<VisitorEntryLog>> GetVisitorHistoryByIdentityAsync(long schoolId, string nationalIdOrPassport, CancellationToken cancellationToken = default);
    
    // جلب الزيارات التي استضافها موظف معين
    Task<IEnumerable<VisitorEntryLog>> GetVisitsByHostEmployeeAsync(long hostEmployeeId, CancellationToken cancellationToken = default);
    
    // 3. Security
    // جلب الزوار الذين تم وسمهم بعلامة تحذير (Flagged) لأسباب أمنية
    Task<IEnumerable<VisitorEntryLog>> GetFlaggedVisitorsAsync(long schoolId, CancellationToken cancellationToken = default);
}



