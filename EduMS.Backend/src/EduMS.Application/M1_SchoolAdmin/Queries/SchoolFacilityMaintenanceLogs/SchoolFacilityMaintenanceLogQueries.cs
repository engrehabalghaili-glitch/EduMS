using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilityMaintenanceLogs;

public class GetSchoolFacilityMaintenanceLogByIdQuery : IRequest<SchoolFacilityMaintenanceLogDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolFacilityMaintenanceLogsQuery : IRequest<IEnumerable<SchoolFacilityMaintenanceLogDto>>
{
}