using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SchoolMergers;

public class CreateSchoolMergerDto
{
    public string MergerNumber { get; set; } = string.Empty;
    public DateTime MergerDate { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string SourceSchoolIdsJson { get; set; } = string.Empty;
    public long TargetSchoolId { get; set; }
    public string? MergerReason { get; set; }
    public string? DecisionAuthority { get; set; }
    public string? DecisionDocumentPath { get; set; }
    public int StudentsTransferStatus { get; set; }
    public int EmployeesTransferStatus { get; set; }
    public int AssetsTransferStatus { get; set; }
    public int MergerStatus { get; set; } = 1;
    public DateTime? CompletionDate { get; set; }
    public string? CompletionNotes { get; set; }
    public string? Notes { get; set; }
}
