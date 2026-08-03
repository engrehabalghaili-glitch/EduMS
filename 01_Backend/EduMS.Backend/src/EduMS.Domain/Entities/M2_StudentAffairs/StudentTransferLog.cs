using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentTransferLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long FromSchoolId { get; set; }
    public long ToSchoolId { get; set; }
    public DateTime TransferDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public int Status { get; set; } // 1 = Pending, 2 = Approved, 3 = Rejected
    public string? TransferCertificateNumber { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public string? MinistryApprovalReference { get; set; }
    public string? TransferRemarks { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual School? FromSchool { get; set; }
    public virtual School? ToSchool { get; set; }
    public virtual Employee? ApprovedByEmployee { get; set; }
}
