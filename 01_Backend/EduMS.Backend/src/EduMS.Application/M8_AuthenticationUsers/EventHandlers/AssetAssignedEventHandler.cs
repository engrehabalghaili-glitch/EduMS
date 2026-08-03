using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Domain.Events;
using MediatR;
using EduMS.Application.Common.Models;

namespace EduMS.Application.M8_AuthenticationUsers.EventHandlers;

public class AssetAssignedEventHandler : INotificationHandler<DomainEventNotification<AssetAssignedDomainEvent>>
{
    private readonly IGenericRepository<SystemAuditLog> _auditRepository;

    public AssetAssignedEventHandler(IGenericRepository<SystemAuditLog> auditRepository)
    {
        _auditRepository = auditRepository;
    }

    public async Task Handle(DomainEventNotification<AssetAssignedDomainEvent> notificationWrapper, CancellationToken cancellationToken)
    {
        var notification = notificationWrapper.DomainEvent;
        var auditLog = new SystemAuditLog
        {
            ActionType = "AssetAssigned",
            EntityType = "SchoolAsset",
            EntityId = notification.AssetId,
            ActionTimestamp = notification.OccurredOn.UtcDateTime,
            ChangeSummary = $"Asset {notification.AssetId} assigned to {notification.AssigneeName} on {notification.AssignmentDate:yyyy-MM-dd}",
            UserId = 1, // System or current user ID
            IpAddress = "127.0.0.1",
            UserAgent = "System/DomainEvent"
        };

        await _auditRepository.AddAsync(auditLog, cancellationToken);
        // Note: UnitOfWork SaveChangesAsync is already in progress and will commit this insertion.
    }
}
