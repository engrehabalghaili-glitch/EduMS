namespace EduMS.Application.Common.Validation;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("حدثت أخطاء في التحقق من البيانات المدخلة.")
    {
        Errors = errors;
    }
}
