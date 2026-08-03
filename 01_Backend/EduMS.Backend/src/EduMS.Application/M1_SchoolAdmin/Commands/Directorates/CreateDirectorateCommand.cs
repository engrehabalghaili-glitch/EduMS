using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Directorates;

public class CreateDirectorateCommand : IRequest<long>
{
    public CreateDirectorateDto Dto { get; set; } = new();
}