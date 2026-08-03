using EduMS.Application.Interfaces.Security;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.Security.Authorization;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly EduMSDbContext _dbContext;

    public PermissionAuthorizationHandler(ICurrentUserService currentUserService, EduMSDbContext dbContext)
    {
        _currentUserService = currentUserService;
        _dbContext = dbContext;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (_currentUserService.UserId == null)
        {
            return; // Not authenticated
        }

        long userId = _currentUserService.UserId.Value;

        // Check Direct User Permissions
        var hasDirectPermission = await _dbContext.UserDirectPermissions
            .Include(dp => dp.Permission)
            .AnyAsync(dp => dp.UserId == userId && dp.Permission!.PermissionKey == requirement.Permission && !dp.IsDeleted);

        if (hasDirectPermission)
        {
            context.Succeed(requirement);
            return;
        }

        // Check Role-Based Permissions
        var hasRolePermission = await _dbContext.UserRoleAssignments
            .Where(ura => ura.UserId == userId && !ura.IsDeleted)
            .Join(_dbContext.RolePermissions,
                  ura => ura.RoleId,
                  rp => rp.RoleId,
                  (ura, rp) => rp)
            .Include(rp => rp.Permission)
            .AnyAsync(rp => rp.Permission!.PermissionKey == requirement.Permission && !rp.IsDeleted);

        if (hasRolePermission)
        {
            context.Succeed(requirement);
            return;
        }

        // Default to not succeeding if no permission found
        return;
    }
}
