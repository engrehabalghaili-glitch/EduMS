using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Locks.Commands;

public class ApplyAcademicLockCommandHandler(IRepository<AcademicLockPeriod> lockRepository)
    : ICommandHandler<ApplyAcademicLockCommand, long>
{
    public async Task<long> HandleAsync(ApplyAcademicLockCommand command, CancellationToken cancellationToken)
    {
        var lockPeriod = new AcademicLockPeriod
        {
            OfficeId = command.OfficeId,
            SchoolId = command.SchoolId,
            PeriodName = command.PeriodName,
            StartDate = command.StartDate,
            EndDate = command.EndDate,
            IsActive = true,
            LockGradeRosters = true,
            LockEnrollmentSnapshots = true,
            LockPeriodStatisticalReports = true
        };

        await lockRepository.AddAsync(lockPeriod, cancellationToken);
        return lockPeriod.Id;
    }
}
