using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.SafetySecurityReports;

public class CreateSafetySecurityReportCommandValidator : AbstractValidator<CreateSafetySecurityReportCommand>
{
    public CreateSafetySecurityReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSafetySecurityReportCommandValidator : AbstractValidator<UpdateSafetySecurityReportCommand>
{
    public UpdateSafetySecurityReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSafetySecurityReportCommandValidator : AbstractValidator<DeleteSafetySecurityReportCommand>
{
    public DeleteSafetySecurityReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}