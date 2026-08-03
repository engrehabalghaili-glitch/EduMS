using EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentExemptions;

public class GetStudentExemptionByIdQuery : IRequest<StudentExemptionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentExemptionsQuery : IRequest<IEnumerable<StudentExemptionDto>>
{
}