using EduMS.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.Jobs;

public class SystemHealthCheckJob : ISystemHealthCheckJob
{
    private readonly ILogger<SystemHealthCheckJob> _logger;

    public SystemHealthCheckJob(ILogger<SystemHealthCheckJob> logger)
    {
        _logger = logger;
    }

    public Task CheckAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("SystemHealthCheckJob executed successfully. The background job processing pipeline is healthy.");
        return Task.CompletedTask;
    }
}
