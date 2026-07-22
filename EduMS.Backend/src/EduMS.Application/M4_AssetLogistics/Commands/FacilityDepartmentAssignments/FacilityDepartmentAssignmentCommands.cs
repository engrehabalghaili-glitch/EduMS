using EduMS.Application.M4_AssetLogistics.DTOs.FacilityDepartmentAssignments;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.FacilityDepartmentAssignments;

public class CreateFacilityDepartmentAssignmentCommand : IRequest<long>
{
    public CreateFacilityDepartmentAssignmentDto Dto { get; set; } = new();
}

public class UpdateFacilityDepartmentAssignmentCommand : IRequest<bool>
{
    public UpdateFacilityDepartmentAssignmentDto Dto { get; set; } = new();
}

public class DeleteFacilityDepartmentAssignmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}