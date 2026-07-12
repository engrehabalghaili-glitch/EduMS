using EduMS.Application.Common.Validation;
using EduMS.Application.Registrations.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Registrations.Validators;

public class CreateRegistrationCommandValidator : IValidator<CreateRegistrationCommand>
{
    public Task ValidateAsync(CreateRegistrationCommand command, CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(command.FirstNameAr) || string.IsNullOrWhiteSpace(command.FatherNameAr) || string.IsNullOrWhiteSpace(command.FamilyNameAr))
        {
            errors.Add("NameAr", new[] { "الاسم العربي الثلاثي مطلوب." });
        }

        if (command.SchoolId <= 0)
        {
            errors.Add(nameof(command.SchoolId), new[] { "معرف المدرسة مطلوب." });
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
