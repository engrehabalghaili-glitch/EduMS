using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolMergers;

public class GetSchoolMergerByIdQuery : IRequest<SchoolMergerDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolMergersQuery : IRequest<IEnumerable<SchoolMergerDto>>
{
}