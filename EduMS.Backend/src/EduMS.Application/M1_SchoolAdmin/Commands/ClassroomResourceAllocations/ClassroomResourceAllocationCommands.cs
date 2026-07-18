using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomResourceAllocations;

public class CreateClassroomResourceAllocationCommand : IRequest<long>
{
    public CreateClassroomResourceAllocationDto Dto { get; set; } = new();
}

public class UpdateClassroomResourceAllocationCommand : IRequest<bool>
{
    public UpdateClassroomResourceAllocationDto Dto { get; set; } = new();
}

public class DeleteClassroomResourceAllocationCommand : IRequest<bool>
{
    public long Id { get; set; }
}