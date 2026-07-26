using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolSurpluses;

public class CreateSchoolSurplusCommandValidator : AbstractValidator<CreateSchoolSurplusCommand>
{
    public CreateSchoolSurplusCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolSurplusCommandValidator : AbstractValidator<UpdateSchoolSurplusCommand>
{
    public UpdateSchoolSurplusCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolSurplusCommandValidator : AbstractValidator<DeleteSchoolSurplusCommand>
{
    public DeleteSchoolSurplusCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}