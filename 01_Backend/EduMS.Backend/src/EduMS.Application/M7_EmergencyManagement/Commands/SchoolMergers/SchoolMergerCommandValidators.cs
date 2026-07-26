using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SchoolMergers;

public class CreateSchoolMergerCommandValidator : AbstractValidator<CreateSchoolMergerCommand>
{
    public CreateSchoolMergerCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolMergerCommandValidator : AbstractValidator<UpdateSchoolMergerCommand>
{
    public UpdateSchoolMergerCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolMergerCommandValidator : AbstractValidator<DeleteSchoolMergerCommand>
{
    public DeleteSchoolMergerCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}