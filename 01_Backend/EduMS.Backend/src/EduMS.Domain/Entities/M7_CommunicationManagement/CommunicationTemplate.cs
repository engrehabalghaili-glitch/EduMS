using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class CommunicationTemplate : BaseAuditableEntity
{
    public string TemplateCode { get; set; } = string.Empty;
    public string TemplateName { get; set; } = string.Empty;
    public string SubjectTemplate { get; set; } = string.Empty;
    public string BodyTemplate { get; set; } = string.Empty;
    public string Type { get; set; } = "Email"; // Email or SMS
}
