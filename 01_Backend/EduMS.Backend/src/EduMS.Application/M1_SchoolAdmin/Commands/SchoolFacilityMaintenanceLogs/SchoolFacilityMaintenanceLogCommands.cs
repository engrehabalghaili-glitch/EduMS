using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilityMaintenanceLogs;

public class CreateSchoolFacilityMaintenanceLogCommand : IRequest<long>
{
    public CreateSchoolFacilityMaintenanceLogDto Dto { get; set; } = new();
}

public class UpdateSchoolFacilityMaintenanceLogCommand : IRequest<bool>
{
    public UpdateSchoolFacilityMaintenanceLogDto Dto { get; set; } = new();
}

public class DeleteSchoolFacilityMaintenanceLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}