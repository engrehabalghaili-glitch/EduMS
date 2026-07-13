using EduMS.Application.Common.Validation;
using EduMS.Application.Registrations.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Registrations.Validators;

public class UpdateRegistrationCommandValidator : IValidator<UpdateRegistrationCommand>
{
    public Task ValidateAsync(UpdateRegistrationCommand command, CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (command.Id <= 0)
        {
            errors.Add(nameof(command.Id), new[] { "معرف الطلب مطلوب." });
        }

        if (string.IsNullOrWhiteSpace(command.FirstNameAr) || string.IsNullOrWhiteSpace(command.FatherNameAr) || string.IsNullOrWhiteSpace(command.FamilyNameAr))
        {
            errors.Add("NameAr", new[] { "الاسم العربي الثلاثي مطلوب." });
        }

        if (!System.Enum.IsDefined(typeof(EduMS.Domain.Enums.Gender), command.Gender))
        {
            errors.Add(nameof(command.Gender), new[] { "قيمة الجنس غير صالحة (1 للذكور، 2 للإناث)." });
        }

        if (!System.Enum.IsDefined(typeof(EduMS.Domain.Enums.RegistrationStatus), command.RequestStatus))
        {
            errors.Add(nameof(command.RequestStatus), new[] { "حالة الطلب غير صالحة." });
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return Task.CompletedTask;
    }
}
