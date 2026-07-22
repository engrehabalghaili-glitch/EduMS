using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolFacilities;

public class CreateSchoolFacilityCommandValidator : AbstractValidator<CreateSchoolFacilityCommand>
{
    public CreateSchoolFacilityCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolFacilityCommandValidator : AbstractValidator<UpdateSchoolFacilityCommand>
{
    public UpdateSchoolFacilityCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolFacilityCommandValidator : AbstractValidator<DeleteSchoolFacilityCommand>
{
    public DeleteSchoolFacilityCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}