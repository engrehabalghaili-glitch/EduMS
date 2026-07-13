using EduMS.Application.Common.Validation;
using EduMS.Application.Persons.Commands;

namespace EduMS.Application.Persons.Validators;

public class CreatePersonCommandValidator : IValidator<CreatePersonCommand>
{
    public Task ValidateAsync(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(command.FullNameAr))
        {
            errors.Add(nameof(command.FullNameAr), new[] { "الاسم الكامل باللغة العربية حقل مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.NationalId))
        {
            errors.Add(nameof(command.NationalId), new[] { "الرقم الوطني حقل مطلوب." });
        }
        else if (command.NationalId.Length < 9 || command.NationalId.Length > 15)
        {
            errors.Add(nameof(command.NationalId), new[] { "يجب أن يكون الرقم الوطني بين 9 و 15 رقماً." });
        }

        if (!System.Enum.IsDefined(typeof(EduMS.Domain.Enums.Gender), command.Gender))
        {
            errors.Add(nameof(command.Gender), new[] { "قيمة الجنس غير صالحة (1 للذكور، 2 للإناث)." });
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return Task.CompletedTask;
    }
}
