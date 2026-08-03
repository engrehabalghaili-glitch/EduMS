using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.M8_AuthenticationUsers.DTOs;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;
using EduMS.Application.Interfaces.Security;
using FluentValidation;
using MediatR;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.Auth
{
    public class LoginQuery : IRequest<string>
    {
        public LoginRequestDto Request { get; set; } = null!;
    }

    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.Request.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Request.Password).NotEmpty().WithMessage("Password is required.");
        }
    }

    public class LoginQueryHandler(ISystemUserRepository userRepository, IUserRoleAssignmentRepository roleAssignmentRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, string>
    {
        private readonly ISystemUserRepository _userRepository = userRepository;
        private readonly IUserRoleAssignmentRepository _roleAssignmentRepository = roleAssignmentRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Request.Username, cancellationToken);

            if (user == null || !user.IsActive)
            {
                throw new ValidationException("Invalid username or password.");
            }

            if (user.IsLocked || user.DeactivationDate.HasValue)
            {
                throw new ValidationException("User account is locked or deactivated.");
            }

            if (!VerifyPbkdf2Hash(request.Request.Password, user.PasswordHash))
            {
                throw new ValidationException("Invalid username or password.");
            }

            var userRoles = await _roleAssignmentRepository.GetAssignmentsByUserIdAsync(user.Id, cancellationToken);
            var roles = userRoles.Where(ura => ura.IsActive && ura.Role != null).Select(ura => ura.Role!.RoleCode).ToList();

            return _jwtTokenGenerator.GenerateToken(user, roles);
        }

        private static bool VerifyPbkdf2Hash(string password, string storedHash)
        {
            try
            {
                var parts = storedHash.Split(':');
                if (parts.Length != 3) return false;

                var iterations = int.Parse(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var hash = Convert.FromBase64String(parts[2]);

                var computedHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    32); 
                
                return CryptographicOperations.FixedTimeEquals(hash, computedHash);
            }
            catch
            {
                return false;
            }
        }
    }
}
