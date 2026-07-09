using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Locks.Queries;

public class CheckAcademicLockQueryHandler(IRepository<AcademicLockPeriod> lockRepository)
    : IQueryHandler<CheckAcademicLockQuery, bool>
{
    public async Task<bool> HandleAsync(CheckAcademicLockQuery query, CancellationToken cancellationToken)
    {
        var locks = await lockRepository.FindAsync(
            l => l.SchoolId == query.SchoolId && 
                 l.IsActive && 
                 query.TargetDate >= l.StartDate && 
                 query.TargetDate <= l.EndDate,
            cancellationToken
        );

        return locks.Any();
    }
}
