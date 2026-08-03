using Microsoft.AspNetCore.Authorization;

namespace EduMS.Infrastructure.Security.Authorization;

/// <summary>
/// Custom authorize attribute that specifies a required permission string.
/// </summary>
public class HasPermissionAttribute : AuthorizeAttribute
{
    const string POLICY_PREFIX = "HasPermission";

    public HasPermissionAttribute(string permission)
    {
        Permission = permission;
    }

    // Get or set the Policy dynamically
    public string Permission
    {
        get
        {
            if (Policy != null && Policy.StartsWith(POLICY_PREFIX))
            {
                return Policy.Substring(POLICY_PREFIX.Length);
            }
            return string.Empty;
        }
        set
        {
            Policy = $"{POLICY_PREFIX}{value}";
        }
    }
}
