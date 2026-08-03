using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentMedicalAllergyLogs;

public class CreateStudentMedicalAllergyLogCommandValidator : AbstractValidator<CreateStudentMedicalAllergyLogCommand>
{
    public CreateStudentMedicalAllergyLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentMedicalAllergyLogCommandValidator : AbstractValidator<UpdateStudentMedicalAllergyLogCommand>
{
    public UpdateStudentMedicalAllergyLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentMedicalAllergyLogCommandValidator : AbstractValidator<DeleteStudentMedicalAllergyLogCommand>
{
    public DeleteStudentMedicalAllergyLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}