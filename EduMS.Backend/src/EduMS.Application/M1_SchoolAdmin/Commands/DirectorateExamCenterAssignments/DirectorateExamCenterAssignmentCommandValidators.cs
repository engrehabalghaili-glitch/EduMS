using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateExamCenterAssignments;

public class CreateDirectorateExamCenterAssignmentCommandValidator : AbstractValidator<CreateDirectorateExamCenterAssignmentCommand>
{
    public CreateDirectorateExamCenterAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDirectorateExamCenterAssignmentCommandValidator : AbstractValidator<UpdateDirectorateExamCenterAssignmentCommand>
{
    public UpdateDirectorateExamCenterAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDirectorateExamCenterAssignmentCommandValidator : AbstractValidator<DeleteDirectorateExamCenterAssignmentCommand>
{
    public DeleteDirectorateExamCenterAssignmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}