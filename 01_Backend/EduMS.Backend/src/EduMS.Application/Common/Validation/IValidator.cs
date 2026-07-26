namespace EduMS.Application.Common.Validation;

public interface IValidator<in T>
{
    Task ValidateAsync(T instance, CancellationToken cancellationToken);
}
