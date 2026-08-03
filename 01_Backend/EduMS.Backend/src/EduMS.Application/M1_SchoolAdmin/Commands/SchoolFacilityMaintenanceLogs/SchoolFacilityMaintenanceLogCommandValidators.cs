using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilityMaintenanceLogs;

public class CreateSchoolFacilityMaintenanceLogCommandValidator : AbstractValidator<CreateSchoolFacilityMaintenanceLogCommand>
{
    public CreateSchoolFacilityMaintenanceLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolFacilityMaintenanceLogCommandValidator : AbstractValidator<UpdateSchoolFacilityMaintenanceLogCommand>
{
    public UpdateSchoolFacilityMaintenanceLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolFacilityMaintenanceLogCommandValidator : AbstractValidator<DeleteSchoolFacilityMaintenanceLogCommand>
{
    public DeleteSchoolFacilityMaintenanceLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}