using MediatR;
using EduMS.Application.M8_AuthenticationUsers.DTOs.Auth;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.LoginUser;

public record LoginUserCommand(string Username, string Password) : IRequest<AuthResponseDto>;
