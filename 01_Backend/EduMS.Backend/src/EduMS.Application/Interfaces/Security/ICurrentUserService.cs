namespace EduMS.Application.Interfaces.Security;

public interface ICurrentUserService
{
    long? UserId { get; }
    string? Username { get; }
    long? TenantId { get; }
    bool IsAuthenticated { get; }
    System.Collections.Generic.IEnumerable<string> Roles { get; }
}



