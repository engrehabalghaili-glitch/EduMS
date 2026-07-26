using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilities;

public class GetSchoolFacilityByIdQuery : IRequest<SchoolFacilityDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolFacilitiesQuery : IRequest<IEnumerable<SchoolFacilityDto>>
{
}