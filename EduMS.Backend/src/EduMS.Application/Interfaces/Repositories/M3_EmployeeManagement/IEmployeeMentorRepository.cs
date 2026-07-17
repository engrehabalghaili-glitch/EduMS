using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeMentorRepository : IGenericRepository<EmployeeMentor>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب عمليات الإرشاد الفعالة حالياً
    Task<IEnumerable<EmployeeMentor>> GetActiveMentorshipsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الموظفين المتدربين (Mentees) الذين يشرف عليهم مرشد (Mentor) محدد
    Task<IEnumerable<EmployeeMentor>> GetMenteesByMentorIdAsync(long mentorId, CancellationToken cancellationToken = default);
    
    // جلب المرشدين لموظف متدرب محدد
    Task<IEnumerable<EmployeeMentor>> GetMentorsByMenteeIdAsync(long menteeId, CancellationToken cancellationToken = default);
    
    // جلب برامج الإرشاد في مدرسة معينة لسنة أكاديمية محددة
    Task<IEnumerable<EmployeeMentor>> GetMentorshipsBySchoolAndYearAsync(long schoolId, long academicYearId, CancellationToken cancellationToken = default);
}
