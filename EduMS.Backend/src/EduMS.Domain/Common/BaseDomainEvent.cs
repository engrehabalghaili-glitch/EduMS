namespace EduMS.Domain.Common;

public abstract class BaseDomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
}
