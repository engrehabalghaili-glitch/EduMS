using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentSkillAndTalentRecords;

public class CreateStudentSkillAndTalentRecordCommandValidator : AbstractValidator<CreateStudentSkillAndTalentRecordCommand>
{
    public CreateStudentSkillAndTalentRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentSkillAndTalentRecordCommandValidator : AbstractValidator<UpdateStudentSkillAndTalentRecordCommand>
{
    public UpdateStudentSkillAndTalentRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentSkillAndTalentRecordCommandValidator : AbstractValidator<DeleteStudentSkillAndTalentRecordCommand>
{
    public DeleteStudentSkillAndTalentRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}