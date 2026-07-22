using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.SelfServicePortalRequests;

public class CreateSelfServicePortalRequestCommandValidator : AbstractValidator<CreateSelfServicePortalRequestCommand>
{
    public CreateSelfServicePortalRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSelfServicePortalRequestCommandValidator : AbstractValidator<UpdateSelfServicePortalRequestCommand>
{
    public UpdateSelfServicePortalRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSelfServicePortalRequestCommandValidator : AbstractValidator<DeleteSelfServicePortalRequestCommand>
{
    public DeleteSelfServicePortalRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}