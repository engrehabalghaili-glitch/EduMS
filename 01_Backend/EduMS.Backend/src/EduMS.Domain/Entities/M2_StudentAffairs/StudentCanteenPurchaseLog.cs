using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentCanteenPurchaseLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolCanteenItemId { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    public int QuantityPurchased { get; set; }
    public decimal TotalCost { get; set; }
    public int PaymentMethod { get; set; } // 1=Cash, 2=StudentCardBalance
    public long? ServedByEmployeeId { get; set; }
    public string? TransactionReferenceNumber { get; set; }
    public int NutritionalCalorieCount { get; set; }
    public bool IsAllergyAlertTriggered { get; set; }
    public long? PaymentTransactionId { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual SchoolCanteenItem? CanteenItem { get; set; }
    public virtual Employee? ServedByEmployee { get; set; }
}
