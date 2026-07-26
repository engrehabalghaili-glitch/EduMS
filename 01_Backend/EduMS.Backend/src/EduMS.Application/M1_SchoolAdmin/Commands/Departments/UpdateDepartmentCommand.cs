using EduMS.Application.M1_SchoolAdmin.DTOs.Departments;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Departments;

public class UpdateDepartmentCommand : IRequest<bool>
{
    public UpdateDepartmentDto Dto { get; set; } = new();
}