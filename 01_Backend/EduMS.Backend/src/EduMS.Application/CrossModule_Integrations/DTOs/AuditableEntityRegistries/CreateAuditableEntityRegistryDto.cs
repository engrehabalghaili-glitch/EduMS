using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.AuditableEntityRegistries;

public class CreateAuditableEntityRegistryDto
{
    public string EntityTypeKey { get; set; } = string.Empty;
    public string SourceModule { get; set; } = string.Empty;
    public string TableNameHint { get; set; } = string.Empty;
    public string EntityNameAr { get; set; } = string.Empty;
    public string? EntityNameEn { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresApprovalToModify { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
