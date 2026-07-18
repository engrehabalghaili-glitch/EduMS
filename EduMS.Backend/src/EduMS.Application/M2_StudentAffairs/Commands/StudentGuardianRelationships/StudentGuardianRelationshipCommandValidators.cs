using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentGuardianRelationships;

public class CreateStudentGuardianRelationshipCommandValidator : AbstractValidator<CreateStudentGuardianRelationshipCommand>
{
    public CreateStudentGuardianRelationshipCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentGuardianRelationshipCommandValidator : AbstractValidator<UpdateStudentGuardianRelationshipCommand>
{
    public UpdateStudentGuardianRelationshipCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentGuardianRelationshipCommandValidator : AbstractValidator<DeleteStudentGuardianRelationshipCommand>
{
    public DeleteStudentGuardianRelationshipCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}