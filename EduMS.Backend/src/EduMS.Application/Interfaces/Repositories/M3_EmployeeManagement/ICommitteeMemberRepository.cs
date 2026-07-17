using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface ICommitteeMemberRepository : IGenericRepository<CommitteeMember>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب جميع أعضاء لجنة محددة
    Task<IEnumerable<CommitteeMember>> GetMembersByCommitteeIdAsync(long committeeId, CancellationToken cancellationToken = default);
    
    // جلب الأعضاء الفعالين في لجنة محددة
    Task<IEnumerable<CommitteeMember>> GetActiveMembersByCommitteeIdAsync(long committeeId, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع اللجان التي يشترك فيها موظف محدد
    Task<IEnumerable<CommitteeMember>> GetCommitteesForEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الأعضاء بناءً على دورهم في اللجنة (رئيس، أمين سر، عضو)
    Task<IEnumerable<CommitteeMember>> GetMembersByRoleAsync(long committeeId, int memberRole, CancellationToken cancellationToken = default);
}
