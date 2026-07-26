namespace EduMS.Application.M8_AuthenticationUsers.DTOs.Auth;

public record AuthResponseDto
{
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public DateTime RefreshTokenExpiration { get; init; }
    public long UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public long? TenantId { get; init; }
}
