using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateExamCenterAssignments;

public class GetDirectorateExamCenterAssignmentByIdQuery : IRequest<DirectorateExamCenterAssignmentDto>
{
    public long Id { get; set; }
}

public class GetAllDirectorateExamCenterAssignmentsQuery : IRequest<IEnumerable<DirectorateExamCenterAssignmentDto>>
{
}