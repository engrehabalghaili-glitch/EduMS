using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAssignments;

public class CreateAssetAssignmentCommandValidator : AbstractValidator<CreateAssetAssignmentCommand>
{
    public CreateAssetAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetAssignmentCommandValidator : AbstractValidator<UpdateAssetAssignmentCommand>
{
    public UpdateAssetAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetAssignmentCommandValidator : AbstractValidator<DeleteAssetAssignmentCommand>
{
    public DeleteAssetAssignmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}