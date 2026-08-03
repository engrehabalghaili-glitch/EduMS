using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.M8_AuthenticationUsers.Commands.LoginUser;
using EduMS.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await sender.Send(command);

        // Append HttpOnly cookie for RefreshToken
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true, // Ensure it's true in production (HTTPS)
            SameSite = SameSiteMode.Strict,
            Expires = result.RefreshTokenExpiration
        };

        Response.Cookies.Append("refreshToken", result.RefreshToken, cookieOptions);

        return Ok(ApiResponse<object>.Success(new 
        {
            result.AccessToken,
            result.UserId,
            result.Username,
            result.TenantId
        }, "Login successful"));
    }
}

