using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Locks.Commands;

public record ApplyAcademicLockCommand(
    long OfficeId,
    long SchoolId,
    string PeriodName,
    DateTime StartDate,
    DateTime EndDate
) : ICommand<long>;
