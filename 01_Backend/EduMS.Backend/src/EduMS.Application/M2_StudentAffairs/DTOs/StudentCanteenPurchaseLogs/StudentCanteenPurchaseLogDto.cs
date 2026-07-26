using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;

public class StudentCanteenPurchaseLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolCanteenItemId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int QuantityPurchased { get; set; }
    public decimal TotalCost { get; set; }
    public int PaymentMethod { get; set; }
    public long? ServedByEmployeeId { get; set; }
    public string? TransactionReferenceNumber { get; set; }
    public int NutritionalCalorieCount { get; set; }
    public bool IsAllergyAlertTriggered { get; set; }
    public long? PaymentTransactionId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
