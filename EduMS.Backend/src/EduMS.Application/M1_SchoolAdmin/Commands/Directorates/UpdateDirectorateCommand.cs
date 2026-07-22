using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Directorates;

public class UpdateDirectorateCommand : IRequest<bool>
{
    public UpdateDirectorateDto Dto { get; set; } = new();
}