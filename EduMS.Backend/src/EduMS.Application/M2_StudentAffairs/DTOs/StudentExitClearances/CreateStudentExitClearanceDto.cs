using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExitClearances;

public class CreateStudentExitClearanceDto
{
    public long StudentId { get; set; }
    public string ClearanceReferenceNumber { get; set; }
    public int ClearanceReason { get; set; }
    public DateTime InitiationDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public bool IsLibraryClearanceApproved { get; set; }
    public bool IsFinancialClearanceApproved { get; set; }
    public bool IsCanteenClearanceApproved { get; set; }
    public bool IsSportsEquipmentClearanceApproved { get; set; }
    public string? ClearanceNotes { get; set; }
}
