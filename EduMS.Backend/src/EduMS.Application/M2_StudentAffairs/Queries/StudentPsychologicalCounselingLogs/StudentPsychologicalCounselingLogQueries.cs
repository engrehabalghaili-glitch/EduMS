using EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentPsychologicalCounselingLogs;

public class GetStudentPsychologicalCounselingLogByIdQuery : IRequest<StudentPsychologicalCounselingLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentPsychologicalCounselingLogsQuery : IRequest<IEnumerable<StudentPsychologicalCounselingLogDto>>
{
}