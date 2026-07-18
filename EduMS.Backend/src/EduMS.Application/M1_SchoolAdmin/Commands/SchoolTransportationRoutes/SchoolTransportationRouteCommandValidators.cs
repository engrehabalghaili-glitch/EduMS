using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolTransportationRoutes;

public class CreateSchoolTransportationRouteCommandValidator : AbstractValidator<CreateSchoolTransportationRouteCommand>
{
    public CreateSchoolTransportationRouteCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolTransportationRouteCommandValidator : AbstractValidator<UpdateSchoolTransportationRouteCommand>
{
    public UpdateSchoolTransportationRouteCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolTransportationRouteCommandValidator : AbstractValidator<DeleteSchoolTransportationRouteCommand>
{
    public DeleteSchoolTransportationRouteCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}