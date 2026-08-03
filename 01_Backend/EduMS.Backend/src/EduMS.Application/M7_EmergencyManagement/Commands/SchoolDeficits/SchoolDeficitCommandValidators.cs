using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolDeficits;

public class CreateSchoolDeficitCommandValidator : AbstractValidator<CreateSchoolDeficitCommand>
{
    public CreateSchoolDeficitCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolDeficitCommandValidator : AbstractValidator<UpdateSchoolDeficitCommand>
{
    public UpdateSchoolDeficitCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolDeficitCommandValidator : AbstractValidator<DeleteSchoolDeficitCommand>
{
    public DeleteSchoolDeficitCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}