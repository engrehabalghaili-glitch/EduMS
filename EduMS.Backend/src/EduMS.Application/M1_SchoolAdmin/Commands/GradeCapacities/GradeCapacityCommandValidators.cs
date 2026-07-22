using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.GradeCapacities;

public class CreateGradeCapacityCommandValidator : AbstractValidator<CreateGradeCapacityCommand>
{
    public CreateGradeCapacityCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateGradeCapacityCommandValidator : AbstractValidator<UpdateGradeCapacityCommand>
{
    public UpdateGradeCapacityCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteGradeCapacityCommandValidator : AbstractValidator<DeleteGradeCapacityCommand>
{
    public DeleteGradeCapacityCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}