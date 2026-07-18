using EduMS.Application.M1_SchoolAdmin.DTOs.Departments;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Departments;

public class CreateDepartmentCommand : IRequest<long>
{
    public CreateDepartmentDto Dto { get; set; } = new();
}