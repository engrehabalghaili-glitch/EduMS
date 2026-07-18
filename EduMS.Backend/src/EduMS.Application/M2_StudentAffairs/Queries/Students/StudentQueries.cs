using EduMS.Application.M2_StudentAffairs.DTOs.Students;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.Students;

public class GetStudentByIdQuery : IRequest<StudentDto>
{
    public long Id { get; set; }
}

public class GetAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
{
}