using EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentActivityParticipations;

public class CreateStudentActivityParticipationCommand : IRequest<long>
{
    public CreateStudentActivityParticipationDto Dto { get; set; } = new();
}

public class UpdateStudentActivityParticipationCommand : IRequest<bool>
{
    public UpdateStudentActivityParticipationDto Dto { get; set; } = new();
}

public class DeleteStudentActivityParticipationCommand : IRequest<bool>
{
    public long Id { get; set; }
}