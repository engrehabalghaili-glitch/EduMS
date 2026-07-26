using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using EduMS.Application.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace EduMS.Infrastructure.Security
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public long? UserId
        {
            get
            {
                var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                                   _httpContextAccessor.HttpContext?.User?.FindFirstValue("sub");
                return long.TryParse(userIdString, out var userId) ? userId : null;
            }
        }

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) ??
                                _httpContextAccessor.HttpContext?.User?.FindFirstValue("email");

        public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ??
                                   _httpContextAccessor.HttpContext?.User?.FindFirstValue("preferred_username");

        public long? TenantId
        {
            get
            {
                var tenantIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue("SchoolId");
                return long.TryParse(tenantIdString, out var tenantId) ? tenantId : null;
            }
        }

        public IEnumerable<string> Roles => _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList() ?? new List<string>();

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
