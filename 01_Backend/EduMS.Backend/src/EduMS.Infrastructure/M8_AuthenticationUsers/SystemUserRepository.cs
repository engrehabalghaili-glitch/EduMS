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
    public class SystemUserRepository(EduMSDbContext dbContext) : Repository<SystemUser>(dbContext), ISystemUserRepository
    {
        public async Task<IEnumerable<SystemUser>> GetActiveUsersAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().Where(u => u.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<SystemUser>> GetLockedUsersAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().Where(u => u.IsLocked).ToListAsync(cancellationToken);
        }

        public async Task<SystemUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<SystemUser?> GetUserByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().FirstOrDefaultAsync(u => u.NationalId == nationalId, cancellationToken);
        }

        public async Task<SystemUser?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().Include(u => u.School).FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
        }

        public async Task<IEnumerable<SystemUser>> GetUsersBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().Where(u => u.SchoolId == schoolId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<SystemUser>> GetUsersByTypeAsync(int userType, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<SystemUser>().Where(u => (int)u.UserType == userType).ToListAsync(cancellationToken);
        }
    }
}
