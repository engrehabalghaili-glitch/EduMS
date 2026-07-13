using EduMS.Application.Common.Validation;
using EduMS.Application.Students.Commands;

namespace EduMS.Application.Students.Validators;

public class EnrollStudentCommandValidator : IValidator<EnrollStudentCommand>
{
    public Task ValidateAsync(EnrollStudentCommand command, CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(command.FullNameAr))
        {
            errors.Add(nameof(command.FullNameAr), new[] { "الاسم الكامل باللغة العربية حقل مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.NationalId))
        {
            errors.Add(nameof(command.NationalId), new[] { "رقم الهوية الوطنية حقل مطلوب." });
        }

        if (command.Gender is not (1 or 2))
        {
            errors.Add(nameof(command.Gender), new[] { "قيمة الجنس غير صالحة (1 للذكور، 2 للإناث)." });
        }

        if (string.IsNullOrWhiteSpace(command.EnrollmentNumber))
        {
            errors.Add(nameof(command.EnrollmentNumber), new[] { "رقم التسجيل أو القيد حقل مطلوب." });
        }

        if (command.SchoolId <= 0)
        {
            errors.Add(nameof(command.SchoolId), new[] { "يجب تحديد رقم مدرسة صحيح." });
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return Task.CompletedTask;
    }
}
