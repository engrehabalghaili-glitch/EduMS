using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.Directorates;

public class CreateDirectorateCommandValidator : AbstractValidator<CreateDirectorateCommand>
{
    public CreateDirectorateCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDirectorateCommandValidator : AbstractValidator<UpdateDirectorateCommand>
{
    public UpdateDirectorateCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDirectorateCommandValidator : AbstractValidator<DeleteDirectorateCommand>
{
    public DeleteDirectorateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}