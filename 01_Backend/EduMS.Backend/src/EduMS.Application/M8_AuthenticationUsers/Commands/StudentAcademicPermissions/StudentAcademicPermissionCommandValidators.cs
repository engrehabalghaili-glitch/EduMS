using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentAcademicPermissions;

public class CreateStudentAcademicPermissionCommandValidator : AbstractValidator<CreateStudentAcademicPermissionCommand>
{
    public CreateStudentAcademicPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAcademicPermissionCommandValidator : AbstractValidator<UpdateStudentAcademicPermissionCommand>
{
    public UpdateStudentAcademicPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAcademicPermissionCommandValidator : AbstractValidator<DeleteStudentAcademicPermissionCommand>
{
    public DeleteStudentAcademicPermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}