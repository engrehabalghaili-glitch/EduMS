using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolTransportationRoutes;

public class CreateSchoolTransportationRouteCommand : IRequest<long>
{
    public CreateSchoolTransportationRouteDto Dto { get; set; } = new();
}

public class UpdateSchoolTransportationRouteCommand : IRequest<bool>
{
    public UpdateSchoolTransportationRouteDto Dto { get; set; } = new();
}

public class DeleteSchoolTransportationRouteCommand : IRequest<bool>
{
    public long Id { get; set; }
}