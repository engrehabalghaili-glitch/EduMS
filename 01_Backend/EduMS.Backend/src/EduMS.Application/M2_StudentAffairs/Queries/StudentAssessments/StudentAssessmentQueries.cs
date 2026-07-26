using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentAssessments;

public class GetStudentAssessmentByIdQuery : IRequest<StudentAssessmentDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAssessmentsQuery : IRequest<IEnumerable<StudentAssessmentDto>>
{
}