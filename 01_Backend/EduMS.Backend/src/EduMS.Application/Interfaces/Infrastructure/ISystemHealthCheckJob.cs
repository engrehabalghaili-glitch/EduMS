using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Interfaces.Infrastructure;

public interface ISystemHealthCheckJob
{
    Task CheckAsync(CancellationToken cancellationToken = default);
}
