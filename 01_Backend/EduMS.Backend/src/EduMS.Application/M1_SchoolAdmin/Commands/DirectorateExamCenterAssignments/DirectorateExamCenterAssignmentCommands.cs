using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateExamCenterAssignments;

public class CreateDirectorateExamCenterAssignmentCommand : IRequest<long>
{
    public CreateDirectorateExamCenterAssignmentDto Dto { get; set; } = new();
}

public class UpdateDirectorateExamCenterAssignmentCommand : IRequest<bool>
{
    public UpdateDirectorateExamCenterAssignmentDto Dto { get; set; } = new();
}

public class DeleteDirectorateExamCenterAssignmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}