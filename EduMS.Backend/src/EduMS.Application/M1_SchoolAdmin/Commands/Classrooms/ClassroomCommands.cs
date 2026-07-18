using EduMS.Application.M1_SchoolAdmin.DTOs.Classrooms;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Classrooms;

public class CreateClassroomCommand : IRequest<long>
{
    public CreateClassroomDto Dto { get; set; } = new();
}

public class UpdateClassroomCommand : IRequest<bool>
{
    public UpdateClassroomDto Dto { get; set; } = new();
}

public class DeleteClassroomCommand : IRequest<bool>
{
    public long Id { get; set; }
}