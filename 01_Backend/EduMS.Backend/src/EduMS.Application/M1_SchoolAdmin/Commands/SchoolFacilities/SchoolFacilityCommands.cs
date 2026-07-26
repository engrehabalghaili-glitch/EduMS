using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilities;

public class CreateSchoolFacilityCommand : IRequest<long>
{
    public CreateSchoolFacilityDto Dto { get; set; } = new();
}

public class UpdateSchoolFacilityCommand : IRequest<bool>
{
    public UpdateSchoolFacilityDto Dto { get; set; } = new();
}

public class DeleteSchoolFacilityCommand : IRequest<bool>
{
    public long Id { get; set; }
}