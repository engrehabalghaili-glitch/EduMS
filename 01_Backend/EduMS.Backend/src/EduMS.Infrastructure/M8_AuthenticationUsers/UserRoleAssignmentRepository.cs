using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.M8_AuthenticationUsers
{
    public class UserRoleAssignmentRepository(EduMSDbContext dbContext) : Repository<UserRoleAssignment>(dbContext), IUserRoleAssignmentRepository
    {
        public async Task<IEnumerable<UserRoleAssignment>> GetActiveAssignmentsAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<UserRoleAssignment>().Where(ura => ura.IsActive).Include(ura => ura.Role).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserRoleAssignment>> GetAssignmentsByRoleIdAsync(long roleId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<UserRoleAssignment>().Where(ura => ura.RoleId == roleId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserRoleAssignment>> GetAssignmentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<UserRoleAssignment>().Where(ura => ura.SchoolId == schoolId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<UserRoleAssignment>> GetAssignmentsByUserIdAsync(long userId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<UserRoleAssignment>().Where(ura => ura.UserId == userId).Include(ura => ura.Role).ToListAsync(cancellationToken);
        }
    }
}
