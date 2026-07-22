using EduMS.Application.M4_AssetLogistics.DTOs.PreventiveMaintenanceSchedules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.PreventiveMaintenanceSchedules;

public class GetPreventiveMaintenanceScheduleByIdQuery : IRequest<PreventiveMaintenanceScheduleDto>
{
    public long Id { get; set; }
}

public class GetAllPreventiveMaintenanceSchedulesQuery : IRequest<IEnumerable<PreventiveMaintenanceScheduleDto>>
{
}