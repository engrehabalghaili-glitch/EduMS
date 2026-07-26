using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentBasePermissions;

public class CreateStudentBasePermissionCommandValidator : AbstractValidator<CreateStudentBasePermissionCommand>
{
    public CreateStudentBasePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentBasePermissionCommandValidator : AbstractValidator<UpdateStudentBasePermissionCommand>
{
    public UpdateStudentBasePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentBasePermissionCommandValidator : AbstractValidator<DeleteStudentBasePermissionCommand>
{
    public DeleteStudentBasePermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}