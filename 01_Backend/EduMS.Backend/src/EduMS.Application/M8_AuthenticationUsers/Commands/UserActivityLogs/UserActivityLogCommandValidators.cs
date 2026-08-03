using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserActivityLogs;

public class CreateUserActivityLogCommandValidator : AbstractValidator<CreateUserActivityLogCommand>
{
    public CreateUserActivityLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateUserActivityLogCommandValidator : AbstractValidator<UpdateUserActivityLogCommand>
{
    public UpdateUserActivityLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteUserActivityLogCommandValidator : AbstractValidator<DeleteUserActivityLogCommand>
{
    public DeleteUserActivityLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}