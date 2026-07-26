using EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExitClearances;

public class CreateStudentExitClearanceCommand : IRequest<long>
{
    public CreateStudentExitClearanceDto Dto { get; set; } = new();
}

public class UpdateStudentExitClearanceCommand : IRequest<bool>
{
    public UpdateStudentExitClearanceDto Dto { get; set; } = new();
}

public class DeleteStudentExitClearanceCommand : IRequest<bool>
{
    public long Id { get; set; }
}