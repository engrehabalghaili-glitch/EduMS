using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Responses;
using EduMS.Application.Interfaces.Security;
using EduMS.Application.M8_AuthenticationUsers.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<string>>> Login(
        [FromBody] LoginRequestDto request, 
        CancellationToken cancellationToken = default)
    {
        var token = await _authService.LoginAsync(request, cancellationToken);
        
        return Ok(ApiResponse<string>.Success(token, "Login successful."));
    }
}
