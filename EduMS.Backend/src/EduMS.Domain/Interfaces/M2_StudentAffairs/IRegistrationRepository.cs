using EduMS.Domain.Entities.M2_StudentAffairs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Domain.Interfaces.M2_StudentAffairs;

public interface IRegistrationRepository
{
    Task<Registration?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Registration>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<long> AddAsync(Registration registration, CancellationToken cancellationToken = default);
    Task UpdateAsync(Registration registration, CancellationToken cancellationToken = default);
    Task DeleteAsync(Registration registration, CancellationToken cancellationToken = default);
}
