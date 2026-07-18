using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.OfficialCirculars;

public class CreateOfficialCircularCommandValidator : AbstractValidator<CreateOfficialCircularCommand>
{
    public CreateOfficialCircularCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateOfficialCircularCommandValidator : AbstractValidator<UpdateOfficialCircularCommand>
{
    public UpdateOfficialCircularCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteOfficialCircularCommandValidator : AbstractValidator<DeleteOfficialCircularCommand>
{
    public DeleteOfficialCircularCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}