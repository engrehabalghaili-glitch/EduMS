using EduMS.Application.M1_SchoolAdmin.Commands;
using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Validators;

public class CreateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
{
    public CreateSchoolCommandValidator()
    {
        RuleFor(x => x.SchoolDto).NotNull().WithMessage("بيانات المدرسة مطلوبة.");

        When(x => x.SchoolDto != null, () =>
        {
            RuleFor(x => x.SchoolDto.SchoolNameAr)
                .NotEmpty().WithMessage("اسم المدرسة بالعربية مطلوب.")
                .MaximumLength(200).WithMessage("اسم المدرسة بالعربية لا يجب أن يتجاوز 200 حرف.");

            RuleFor(x => x.SchoolDto.SchoolNameEn)
                .NotEmpty().WithMessage("اسم المدرسة بالإنجليزية مطلوب.")
                .MaximumLength(200).WithMessage("اسم المدرسة بالإنجليزية لا يجب أن يتجاوز 200 حرف.");

            RuleFor(x => x.SchoolDto.SchoolCode)
                .NotEmpty().WithMessage("رمز المدرسة مطلوب.")
                .MaximumLength(50).WithMessage("رمز المدرسة لا يجب أن يتجاوز 50 حرف.");

            RuleFor(x => x.SchoolDto.Directorate)
                .NotEmpty().WithMessage("الإدارة التعليمية مطلوبة.");

            RuleFor(x => x.SchoolDto.Governorate)
                .NotEmpty().WithMessage("المحافظة مطلوبة.");

            RuleFor(x => x.SchoolDto.MaxStudentCapacity)
                .GreaterThan(0).WithMessage("السعة القصوى للطلاب يجب أن تكون أكبر من الصفر.");

            RuleFor(x => x.SchoolDto.ContactEmail)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.SchoolDto.ContactEmail))
                .WithMessage("البريد الإلكتروني غير صالح.");
        });
    }
}
