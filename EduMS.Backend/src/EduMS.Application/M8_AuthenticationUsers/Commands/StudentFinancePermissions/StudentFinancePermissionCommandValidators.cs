using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentFinancePermissions;

public class CreateStudentFinancePermissionCommandValidator : AbstractValidator<CreateStudentFinancePermissionCommand>
{
    public CreateStudentFinancePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentFinancePermissionCommandValidator : AbstractValidator<UpdateStudentFinancePermissionCommand>
{
    public UpdateStudentFinancePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentFinancePermissionCommandValidator : AbstractValidator<DeleteStudentFinancePermissionCommand>
{
    public DeleteStudentFinancePermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}