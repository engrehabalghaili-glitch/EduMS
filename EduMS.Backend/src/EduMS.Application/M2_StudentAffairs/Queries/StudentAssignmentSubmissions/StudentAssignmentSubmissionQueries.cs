using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAssignmentSubmissions;

public class GetStudentAssignmentSubmissionByIdQuery : IRequest<StudentAssignmentSubmissionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAssignmentSubmissionsQuery : IRequest<IEnumerable<StudentAssignmentSubmissionDto>>
{
}