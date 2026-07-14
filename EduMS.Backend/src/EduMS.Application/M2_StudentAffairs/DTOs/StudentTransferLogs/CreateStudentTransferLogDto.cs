using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;

public class CreateStudentTransferLogDto
{
    public long StudentId { get; set; }
    public long FromSchoolId { get; set; }
    public long ToSchoolId { get; set; }
    public DateTime TransferDate { get; set; }
    public string Reason { get; set; }
    public string? TransferCertificateNumber { get; set; }
    public string? MinistryApprovalReference { get; set; }
    public string? TransferRemarks { get; set; }
}
