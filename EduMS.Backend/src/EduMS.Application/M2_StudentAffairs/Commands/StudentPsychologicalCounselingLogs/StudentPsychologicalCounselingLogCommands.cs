using EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentPsychologicalCounselingLogs;

public class CreateStudentPsychologicalCounselingLogCommand : IRequest<long>
{
    public CreateStudentPsychologicalCounselingLogDto Dto { get; set; } = new();
}

public class UpdateStudentPsychologicalCounselingLogCommand : IRequest<bool>
{
    public UpdateStudentPsychologicalCounselingLogDto Dto { get; set; } = new();
}

public class DeleteStudentPsychologicalCounselingLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}