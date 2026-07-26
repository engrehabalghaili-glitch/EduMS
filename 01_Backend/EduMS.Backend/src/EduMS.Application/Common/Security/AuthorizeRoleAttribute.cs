using System;

namespace EduMS.Application.Common.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeRoleAttribute : Attribute
    {
        public string Roles { get; }

        public AuthorizeRoleAttribute(string roles)
        {
            Roles = roles;
        }
    }
}
