using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;
using FluentValidation;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.Auth
{
    public class RegisterUserCommand : IRequest<long>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long? SchoolId { get; set; }
        public long RoleId { get; set; }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(4).MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Matches("[A-Z]").Matches("[a-z]").Matches("[0-9]");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }

    public class RegisterUserCommandHandler(ISystemUserRepository userRepository, IUserRoleAssignmentRepository roleAssignmentRepository, EduMS.Application.Interfaces.Repositories.Common.IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, long>
    {
        private readonly ISystemUserRepository _userRepository = userRepository;
        private readonly IUserRoleAssignmentRepository _roleAssignmentRepository = roleAssignmentRepository;
        private readonly EduMS.Application.Interfaces.Repositories.Common.IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<long> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Check if username exists
            if (await _userRepository.GetUserByUsernameAsync(request.Username, cancellationToken) != null)
            {
                throw new EduMS.Application.Common.Validation.ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Username", "Username is already taken.") });
            }

            // Generate PBKDF2 hash
            var passwordHash = GeneratePbkdf2Hash(request.Password);

            var user = new SystemUser
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                Email = request.Email,
                SchoolId = request.SchoolId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            // Assign role
            var roleAssignment = new UserRoleAssignment
            {
                UserId = user.Id,
                RoleId = request.RoleId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _roleAssignmentRepository.AddAsync(roleAssignment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        private static string GeneratePbkdf2Hash(string password, int iterations = 100000)
        {
            var salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                32); // 32-byte hash size

            return $"{iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }
    }
}
