namespace EduMS.Domain.Enums;

public enum SyncStatus
{
    Synced = 0,     // متزامن مع الخادم السحابي
    Pending = 1,    // معلق بانتظار المزامنة
    Conflict = 2    // وجود تعارض في البيانات يحتاج لمعالجة
}
