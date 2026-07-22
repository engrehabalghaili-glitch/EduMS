using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Common.Exceptions;
using EduMS.Application.Interfaces.Security;
using EduMS.Application.M8_AuthenticationUsers.DTOs;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EduMS.WebApi.Infrastructure;

public class AuthService(EduMSDbContext context, IConfiguration configuration, ILogger<AuthService> logger) : IAuthService
{
    private readonly EduMSDbContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly ILogger<AuthService> _logger = logger;

    public async Task<string> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
    {
        var user = await _context.Set<SystemUser>()
            .Include(u => u.School)
            .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive, cancellationToken);

        if (user == null)
        {
            throw new ValidationException("Invalid username or password.");
        }

        if (user.IsLocked || user.DeactivationDate.HasValue)
        {
            throw new ValidationException("User account is locked or deactivated.");
        }

        if (!VerifyPbkdf2Hash(request.Password, user.PasswordHash))
        {
            // Update failed attempts and lock out logic here if necessary in a full implementation
            throw new ValidationException("Invalid username or password.");
        }

        return await GenerateJwtTokenAsync(user, cancellationToken);
    }

    private async Task<string> GenerateJwtTokenAsync(SystemUser user, CancellationToken cancellationToken)
    {
        var roles = await _context.Set<UserRoleAssignment>()
            .Include(ura => ura.Role)
            .Where(ura => ura.UserId == user.Id && ura.IsActive)
            .Select(ura => ura.Role!.RoleCode)
            .ToListAsync(cancellationToken);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
        };

        if (user.SchoolId.HasValue)
        {
            claims.Add(new Claim("SchoolId", user.SchoolId.Value.ToString()));
        }

        foreach (var role in roles)
        {
            if (!string.IsNullOrEmpty(role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }

        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey is missing.");
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"] ?? "60");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var computedHash = pbkdf2.GetBytes(32); // Assuming 32-byte hash size
            
            return CryptographicOperations.FixedTimeEquals(hash, computedHash);
        }
        catch
        {
            return false;
        }
    }

    public static string GeneratePbkdf2Hash(string password, int iterations = 100000)
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32);

        return $"{iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }
}
