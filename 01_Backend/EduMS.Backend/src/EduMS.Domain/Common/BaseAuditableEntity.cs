using EduMS.Domain.Enums;

namespace EduMS.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    // حقول التدقيق والتحقق الأساسية (Audit Log Fields)
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }

    // حقول التتبع للحذف المنطقي (Soft Delete Support)
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }

    // حقول تتبع إطار عمل المزامنة المحلية (Offline Sync Abstraction)
    public Guid VersionToken { get; set; } = Guid.NewGuid(); // RAW(16) لتجنب التصادم
    public SyncStatus SyncStatus { get; set; } = SyncStatus.Pending;
    public DateTimeOffset? LastSyncedAt { get; set; }
}
