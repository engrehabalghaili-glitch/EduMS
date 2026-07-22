using EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentActivityParticipations;

public class GetStudentActivityParticipationByIdQuery : IRequest<StudentActivityParticipationDto>
{
    public long Id { get; set; }
}

public class GetAllStudentActivityParticipationsQuery : IRequest<IEnumerable<StudentActivityParticipationDto>>
{
}