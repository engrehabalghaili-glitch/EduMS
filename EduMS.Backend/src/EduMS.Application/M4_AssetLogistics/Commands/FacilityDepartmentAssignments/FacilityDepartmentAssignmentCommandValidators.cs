using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.FacilityDepartmentAssignments;

public class CreateFacilityDepartmentAssignmentCommandValidator : AbstractValidator<CreateFacilityDepartmentAssignmentCommand>
{
    public CreateFacilityDepartmentAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFacilityDepartmentAssignmentCommandValidator : AbstractValidator<UpdateFacilityDepartmentAssignmentCommand>
{
    public UpdateFacilityDepartmentAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFacilityDepartmentAssignmentCommandValidator : AbstractValidator<DeleteFacilityDepartmentAssignmentCommand>
{
    public DeleteFacilityDepartmentAssignmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}