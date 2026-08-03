using EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAbsenceExcusals;

public class GetStudentAbsenceExcusalByIdQuery : IRequest<StudentAbsenceExcusalDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAbsenceExcusalsQuery : IRequest<IEnumerable<StudentAbsenceExcusalDto>>
{
}