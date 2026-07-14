using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentCanteenPurchaseLogs;

public class UpdateStudentCanteenPurchaseLogDto
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
}
