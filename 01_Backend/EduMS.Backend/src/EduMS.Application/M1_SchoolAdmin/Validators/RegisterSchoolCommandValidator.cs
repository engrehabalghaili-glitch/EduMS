using EduMS.Application.Schools.Commands;
using FluentValidation;

namespace EduMS.Application.Schools.Validators;

public class RegisterSchoolCommandValidator : AbstractValidator<RegisterSchoolCommand>, EduMS.Application.Common.Validation.IValidator<RegisterSchoolCommand>
{
    public RegisterSchoolCommandValidator()
    {
        RuleFor(x => x.SchoolNameAr)
            .NotEmpty().WithMessage("اسم المدرسة بالعربية حقل مطلوب.")
            .MaximumLength(200).WithMessage("اسم المدرسة بالعربية لا يجب أن يتجاوز 200 حرف.");

        RuleFor(x => x.SchoolCode)
            .NotEmpty().WithMessage("رمز المدرسة حقل مطلوب.")
            .MaximumLength(50).WithMessage("رمز المدرسة لا يجب أن يتجاوز 50 حرف.");

        RuleFor(x => x.Directorate)
            .NotEmpty().WithMessage("اسم الإدارة التعليمية حقل مطلوب.");

        RuleFor(x => x.Governorate)
            .NotEmpty().WithMessage("اسم المحافظة حقل مطلوب.");
    }

    public new async Task ValidateAsync(RegisterSchoolCommand instance, CancellationToken cancellationToken)
    {
        var result = await ((FluentValidation.IValidator<RegisterSchoolCommand>)this).ValidateAsync(instance, cancellationToken);
        if (!result.IsValid)
        {
            throw new EduMS.Application.Common.Validation.ValidationException(result.Errors);
        }
    }
}

