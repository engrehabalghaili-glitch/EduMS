using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.OrganizationalSectors;

public class CreateOrganizationalSectorCommandValidator : AbstractValidator<CreateOrganizationalSectorCommand>
{
    public CreateOrganizationalSectorCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateOrganizationalSectorCommandValidator : AbstractValidator<UpdateOrganizationalSectorCommand>
{
    public UpdateOrganizationalSectorCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteOrganizationalSectorCommandValidator : AbstractValidator<DeleteOrganizationalSectorCommand>
{
    public DeleteOrganizationalSectorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}