using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Events;

public class AssetAssignedDomainEvent : IDomainEvent
{
    public long AssetId { get; }
    public string AssigneeName { get; }
    public DateTime AssignmentDate { get; }
    public DateTimeOffset OccurredOn { get; }

    public AssetAssignedDomainEvent(long assetId, string assigneeName, DateTime assignmentDate)
    {
        AssetId = assetId;
        AssigneeName = assigneeName;
        AssignmentDate = assignmentDate;
        OccurredOn = DateTimeOffset.UtcNow;
    }
}
