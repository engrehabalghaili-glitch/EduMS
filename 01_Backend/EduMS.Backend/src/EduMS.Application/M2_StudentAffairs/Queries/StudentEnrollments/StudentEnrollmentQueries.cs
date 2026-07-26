using EduMS.Application.M2_StudentAffairs.DTOs.StudentEnrollments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentEnrollments;

public class GetStudentEnrollmentByIdQuery : IRequest<StudentEnrollmentDto>
{
    public long Id { get; set; }
}

public class GetAllStudentEnrollmentsQuery : IRequest<IEnumerable<StudentEnrollmentDto>>
{
}