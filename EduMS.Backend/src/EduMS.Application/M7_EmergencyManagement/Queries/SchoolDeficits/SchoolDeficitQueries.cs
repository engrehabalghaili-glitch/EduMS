using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolDeficits;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolDeficits;

public class GetSchoolDeficitByIdQuery : IRequest<SchoolDeficitDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolDeficitsQuery : IRequest<IEnumerable<SchoolDeficitDto>>
{
}