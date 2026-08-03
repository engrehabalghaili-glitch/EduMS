using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolTransportationRoutes;

public class GetSchoolTransportationRouteByIdQuery : IRequest<SchoolTransportationRouteDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolTransportationRoutesQuery : IRequest<IEnumerable<SchoolTransportationRouteDto>>
{
}