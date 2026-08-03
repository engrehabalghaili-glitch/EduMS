using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Security;
using MediatR;

namespace EduMS.Application.Common.Security
{
    public class AuthorizationBehavior<TRequest, TResponse>(ICurrentUserService currentUserService) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeRoleAttribute>();

            if (authorizeAttributes.Any())
            {
                if (!_currentUserService.IsAuthenticated)
                {
                    throw new UnauthorizedAccessException();
                }

                var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));

                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
                    {
                        if (roles.Any(role => _currentUserService.Roles.ToList().ToList().Contains(role.Trim())))
                        {
                            authorized = true;
                            break;
                        }
                    }

                    if (!authorized)
                    {
                        throw new UnauthorizedAccessException("User does not have the required role.");
                    }
                }
            }

            return await next();
        }
    }
}


