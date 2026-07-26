using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolAwards;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolAwards;

public class GetSchoolAwardByIdQuery : IRequest<SchoolAwardDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAwardsQuery : IRequest<IEnumerable<SchoolAwardDto>>
{
}