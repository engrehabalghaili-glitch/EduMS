using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolAwards;

public class CreateSchoolAwardCommandValidator : AbstractValidator<CreateSchoolAwardCommand>
{
    public CreateSchoolAwardCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAwardCommandValidator : AbstractValidator<UpdateSchoolAwardCommand>
{
    public UpdateSchoolAwardCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAwardCommandValidator : AbstractValidator<DeleteSchoolAwardCommand>
{
    public DeleteSchoolAwardCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}