using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolCanteenItems;

public class CreateSchoolCanteenItemCommandValidator : AbstractValidator<CreateSchoolCanteenItemCommand>
{
    public CreateSchoolCanteenItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolCanteenItemCommandValidator : AbstractValidator<UpdateSchoolCanteenItemCommand>
{
    public UpdateSchoolCanteenItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolCanteenItemCommandValidator : AbstractValidator<DeleteSchoolCanteenItemCommand>
{
    public DeleteSchoolCanteenItemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}