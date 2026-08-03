using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class MessageQueue : BaseAuditableEntity
{
    public string MessageType { get; set; } = "Email"; // Email or SMS
    public string RecipientAddress { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending, Sent, Failed
    public int RetryCount { get; set; } = 0;
}
