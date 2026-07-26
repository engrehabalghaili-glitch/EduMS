using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Exceptions;
using EduMS.Application.Interfaces.Repositories.M8_AuthenticationUsers;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Application.Interfaces.Security;
using EduMS.Application.M8_AuthenticationUsers.DTOs.Auth;
using EduMS.Domain.Entities;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.LoginUser;

public class LoginCommandHandler : IRequestHandler<LoginUserCommand, AuthResponseDto>
{
    private readonly ISystemUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginCommandHandler(ISystemUserRepository repository, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var users = await _repository.FindWithIncludesAsync(
            u => u.Username == request.Username, 
            cancellationToken,
            u => u.UserRoleAssignments
        );

        var user = users.FirstOrDefault();

        if (user == null || !user.IsActive || user.IsLocked)
        {
            throw new UnauthorizedAccessException("Invalid credentials or inactive account.");
        }

        bool isPasswordValid = global::BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!isPasswordValid)
        {
            user.FailedAttempts++;
            user.LastFailedAttemptDate = DateTime.UtcNow;
            
            if (user.FailedAttempts >= 5)
            {
                user.IsLocked = true;
                user.LockReason = "Too many failed login attempts";
                user.LockExpiryDate = DateTime.UtcNow.AddMinutes(30);
            }
            
            await _repository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        user.FailedAttempts = 0;
        user.LastFailedAttemptDate = null;
        user.LastLoginDate = DateTime.UtcNow;

        var roles = user.UserRoleAssignments
            .Where(ur => ur.IsActive && ur.Role != null)
            .Select(ur => ur.Role!.RoleNameEn)
            .ToList();

        var accessToken = _jwtTokenGenerator.GenerateToken(user, roles);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();
        var refreshTokenExpiry = DateTime.UtcNow.AddDays(7); 

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = refreshTokenExpiry;

        await _repository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpiration = refreshTokenExpiry,
            UserId = user.Id,
            Username = user.Username,
            TenantId = user.SchoolId
        };
    }
}

