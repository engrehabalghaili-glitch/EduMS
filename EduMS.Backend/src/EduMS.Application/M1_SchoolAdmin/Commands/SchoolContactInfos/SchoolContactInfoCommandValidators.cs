using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolContactInfos;

public class CreateSchoolContactInfoCommandValidator : AbstractValidator<CreateSchoolContactInfoCommand>
{
    public CreateSchoolContactInfoCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolContactInfoCommandValidator : AbstractValidator<UpdateSchoolContactInfoCommand>
{
    public UpdateSchoolContactInfoCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolContactInfoCommandValidator : AbstractValidator<DeleteSchoolContactInfoCommand>
{
    public DeleteSchoolContactInfoCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}