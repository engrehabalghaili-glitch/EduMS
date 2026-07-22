using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.M8_AuthenticationUsers.DTOs;

namespace EduMS.Application.Interfaces.Security;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
}
