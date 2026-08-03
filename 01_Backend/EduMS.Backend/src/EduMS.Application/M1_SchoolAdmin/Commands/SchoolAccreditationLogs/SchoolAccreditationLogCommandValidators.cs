using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAccreditationLogs;

public class CreateSchoolAccreditationLogCommandValidator : AbstractValidator<CreateSchoolAccreditationLogCommand>
{
    public CreateSchoolAccreditationLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAccreditationLogCommandValidator : AbstractValidator<UpdateSchoolAccreditationLogCommand>
{
    public UpdateSchoolAccreditationLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAccreditationLogCommandValidator : AbstractValidator<DeleteSchoolAccreditationLogCommand>
{
    public DeleteSchoolAccreditationLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}