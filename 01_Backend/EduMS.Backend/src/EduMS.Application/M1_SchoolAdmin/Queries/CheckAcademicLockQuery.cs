using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Locks.Queries;

public record CheckAcademicLockQuery(
    long SchoolId,
    DateTime TargetDate
) : IQuery<bool>;
