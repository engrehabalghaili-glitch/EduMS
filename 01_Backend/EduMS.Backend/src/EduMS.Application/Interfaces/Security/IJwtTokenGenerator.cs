using System.Collections.Generic;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(SystemUser user, IEnumerable<string> roles);
        string GenerateRefreshToken();
    }
}

