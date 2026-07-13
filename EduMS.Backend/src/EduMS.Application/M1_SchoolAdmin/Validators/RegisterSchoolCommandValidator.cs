using EduMS.Application.Common.Validation;
using EduMS.Application.Schools.Commands;

namespace EduMS.Application.Schools.Validators;

public class RegisterSchoolCommandValidator : IValidator<RegisterSchoolCommand>
{
    public Task ValidateAsync(RegisterSchoolCommand command, CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(command.SchoolNameAr))
        {
            errors.Add(nameof(command.SchoolNameAr), new[] { "اسم المدرسة بالعربية حقل مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.SchoolCode))
        {
            errors.Add(nameof(command.SchoolCode), new[] { "رمز المدرسة حقل مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.Directorate))
        {
            errors.Add(nameof(command.Directorate), new[] { "اسم الإدارة التعليمية حقل مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.Governorate))
        {
            errors.Add(nameof(command.Governorate), new[] { "اسم المحافظة حقل مطلوب." });
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return Task.CompletedTask;
    }
}
