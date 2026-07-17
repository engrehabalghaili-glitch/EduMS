using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeCommitteeRepository : IGenericRepository<EmployeeCommittee>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب اللجان بناءً على نوعها (تأديبية، أكاديمية، مشتريات، الخ)
    Task<IEnumerable<EmployeeCommittee>> GetCommitteesByTypeAsync(int committeeType, CancellationToken cancellationToken = default);
    
    // جلب اللجان الفعالة (النشطة)
    Task<IEnumerable<EmployeeCommittee>> GetActiveCommitteesAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب لجان مدرسة محددة
    Task<IEnumerable<EmployeeCommittee>> GetCommitteesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب اللجان التي يرأسها موظف محدد
    Task<IEnumerable<EmployeeCommittee>> GetCommitteesByChairmanAsync(long chairmanEmployeeId, CancellationToken cancellationToken = default);
}
