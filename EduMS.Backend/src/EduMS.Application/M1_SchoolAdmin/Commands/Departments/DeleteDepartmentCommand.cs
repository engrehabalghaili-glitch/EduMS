using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Departments;

public class DeleteDepartmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}