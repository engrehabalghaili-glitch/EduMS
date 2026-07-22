using EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExitClearances;

public class GetStudentExitClearanceByIdQuery : IRequest<StudentExitClearanceDto>
{
    public long Id { get; set; }
}

public class GetAllStudentExitClearancesQuery : IRequest<IEnumerable<StudentExitClearanceDto>>
{
}