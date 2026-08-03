using System.Security.Claims;
using EduMS.Application.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace EduMS.WebApi.Infrastructure;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public long? UserId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? 
                        _httpContextAccessor.HttpContext?.User?.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);
            return long.TryParse(value, out var id) ? id : null;
        }
    }

    public string? Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);

    public long? TenantId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?.User?.FindFirstValue("TenantId");
            return long.TryParse(value, out var id) ? id : null;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public System.Collections.Generic.IEnumerable<string> Roles => _httpContextAccessor.HttpContext?.User?.FindAll(System.Security.Claims.ClaimTypes.Role).Select(c => c.Value) ?? System.Linq.Enumerable.Empty<string>();
}

