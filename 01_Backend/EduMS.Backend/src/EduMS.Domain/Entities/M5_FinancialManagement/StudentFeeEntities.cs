using System;
using System.Collections.Generic;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الحساب المالي للطالب - Student financial account extracted from ZIP ERD StudentAccount (lines 7727-7830).
/// One-to-one with Student; tracks total dues, payments, balance, and exemption status.
/// Oracle 19c Safe Primitive Types and PascalCase Naming.
/// </summary>
public class StudentAccount : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    
    // Core Financial Balances (High-Precision Decimals)
    public decimal TotalDebit { get; set; } // إجمالي الرسوم المستحقة مدين
    public decimal TotalCredit { get; set; } // إجمالي المدفوعات دائن
    public decimal CurrentBalance { get; set; } // الرصيد الحالي
    public int BalanceType { get; set; } // 1=Debit, 2=Credit, 3=Zero
    
    // Legacy Compatibility Aliases
    public decimal TotalDues { get => TotalDebit; set => TotalDebit = value; }
    public decimal TotalPaid { get => TotalCredit; set => TotalCredit = value; }
    public decimal OutstandingBalance { get => CurrentBalance; set => CurrentBalance = value; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalExemption { get; set; }
    
    // Transaction History Tracking
    public DateTime? LastTransactionDate { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public decimal? LastPaymentAmount { get; set; }
    public int AccountStatus { get; set; } = 1; // 1=Active, 2=Settled, 3=Suspended, 4=Deferred, 5=Closed
    
    // Exemption and Grant Details
    public bool IsExempt { get; set; }
    public decimal? ExemptionPercentage { get; set; }
    public string? ExemptionReason { get; set; }
    public long? ExemptionApprovedByUserId { get; set; }
    public DateTime? ExemptionApprovalDate { get; set; }
    public string? ExemptionDocumentUrl { get; set; }
    
    // Registration Controls
    public decimal? MinimumPaymentRequired { get; set; }
    public bool IsBlockedFromRegistration { get; set; }
    public string? BlockReason { get; set; }
    public DateTime? UnblockDate { get; set; }
    public string? PaymentPlan { get; set; }
    public bool IsEligibleForExam { get; set; } = true;
    public string? Notes { get; set; }

    public virtual Student? Student { get; set; }
}

/// <summary>
/// نوع الرسوم الدراسية وقوائم أسعارها - Fee type lookup extracted from ZIP ERD FeeType table.
/// </summary>
public class FeeType : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? GradeCapacityId { get; set; }
    public string FeeCode { get; set; } = string.Empty;
    public string FeeNameAr { get; set; } = string.Empty;
    public string? FeeNameEn { get; set; }
    public int FeeCategory { get; set; } // 1=Tuition, 2=Registration, 3=Bus, 4=Uniform, 5=Books, 6=Activities, 7=Exam, 8=Other
    
    public decimal Amount { get; set; } // المبلغ الافتراضي قبل الخصم
    public decimal DefaultAmount { get => Amount; set => Amount = value; }
    public string Currency { get; set; } = "SAR";
    public string BillingFrequency { get; set; } = "Annual"; // Monthly, Semester, Annual, OneTime
    
    // Tax and Mandatory Configuration
    public bool IsTaxable { get; set; }
    public decimal TaxPercentage { get; set; } = 15m;
    public bool IsMandatory { get; set; }
    public bool IsOptional { get; set; }
    
    // Discount and Refund Policies
    public bool IsDiscountable { get; set; }
    public decimal? DiscountPercentageAllowed { get; set; }
    public bool IsRefundable { get; set; }
    public decimal? RefundPercentage { get; set; }
    public DateTime? RefundCutoffDate { get; set; }
    
    // Recurrence & Applicability Scope
    public bool IsRecurring { get; set; }
    public string? RecurrenceType { get; set; }
    public string? AppliesToGradesJson { get; set; }
    public string? AppliesToNationalitiesJson { get; set; }
    public string? AppliesToStudentTypesJson { get; set; }
    
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? DescriptionAr { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// فاتورة رسوم الطالب - Student fee invoice extracted from ZIP ERD StudentInvoice table.
/// </summary>
public class StudentInvoice : BaseAuditableEntity
{
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public DateTime? IssueDate { get; set; }
    
    // High-Precision Monetary Breakdown
    public decimal TotalAmount { get; set; } // قبل الخصم والضريبة
    public decimal SubtotalAmount { get => TotalAmount; set => TotalAmount = value; }
    public decimal DiscountAmount { get; set; }
    public int? DiscountReason { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TaxRate { get; set; } = 15m;
    public string? TaxRegistrationNumber { get; set; }
    public decimal NetAmount { get; set; } // المبلغ الصافي
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; } // المبلغ المتبقي
    public decimal BalanceDue { get => RemainingAmount; set => RemainingAmount = value; }
    
    // Classification and Status
    public string InvoiceType { get; set; } = string.Empty; // Tuition, Books, Transport, Uniform, Activity
    public string InvoiceCategory { get; set; } = "Mandatory"; // Mandatory, Optional
    public int PaymentStatus { get; set; } = 1; // 1=Unpaid, 2=PartiallyPaid, 3=FullyPaid, 4=Cancelled
    public int InvoiceStatus { get; set; } = 1; // 1=Draft, 2=Issued, 3=Locked, 4=Cancelled, 5=Closed
    public string? PaymentMethod { get; set; }
    
    // Late Fees & Installment Tracking
    public bool IsLate { get; set; }
    public int? LateDays { get; set; }
    public decimal? LateFeePercentage { get; set; }
    public decimal? LateFeeAmount { get; set; }
    public bool InstallmentPlan { get; set; }
    public int? InstallmentCount { get; set; }
    public int? CurrentInstallment { get; set; }
    
    // Parent Notification & Approval Workflow
    public bool ParentApprovalRequired { get; set; }
    public int ParentApprovalStatus { get; set; } = 1; // 1=Pending, 2=Approved, 3=Rejected
    public DateTime? ParentApprovalDate { get; set; }
    public bool SentToParent { get; set; }
    public DateTime? ParentNotifiedAt { get; set; }
    public string? Notes { get; set; }

    public virtual StudentAccount? StudentAccount { get; set; }
    public virtual Student? Student { get; set; }
}

/// <summary>
/// بند في فاتورة الطالب - Invoice line item extracted from ZIP ERD InvoiceItem table.
/// </summary>
public class InvoiceItem : BaseAuditableEntity
{
    public long InvoiceId { get; set; }
    public long FeeTypeId { get; set; }
    public string? ItemCode { get; set; }
    public string ItemDescription { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Discount and Tax at Item Level
    public decimal? DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal PriceAfterDiscount { get; set; }
    public decimal? TaxPercentage { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    
    // Due Dates, Payments & Late Fees
    public DateTime? DueDate { get; set; }
    public bool IsPaid { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? PaymentMethod { get; set; }
    public bool IsLate { get; set; }
    public bool LateFeeApplied { get; set; }
    public decimal? LateFeeAmount { get; set; }
    
    // Installment & Waiver Links
    public int? InstallmentNumber { get; set; }
    public int? InstallmentTotal { get; set; }
    public bool IsWaived { get; set; }
    public string? WaiverReason { get; set; }
    public DateTime? WaiverDate { get; set; }
    public int Status { get; set; } = 1; // 1=Active, 2=Paid, 3=Cancelled, 4=Waived
    public string? Notes { get; set; }

    public virtual StudentInvoice? Invoice { get; set; }
    public virtual FeeType? FeeType { get; set; }
}

/// <summary>
/// قسط سداد الفاتورة - Installment plan extracted from ZIP ERD Installment table.
/// </summary>
public class FeeInstallment : BaseAuditableEntity
{
    public long InvoiceId { get; set; }
    public long? ItemId { get; set; } // Optional if installment is for specific line item
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    
    public int InstallmentNumber { get; set; }
    public int InstallmentTotal { get; set; }
    public decimal InstallmentAmount { get; set; }
    public string Currency { get; set; } = "SAR";
    public DateTime DueDate { get; set; }
    public DateTime? ExtendedDueDate { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentReference { get; set; }
    public string? InstallmentType { get; set; } // Regular, DownPayment, Final
    public int InstallmentStatus { get; set; } = 1; // 1=Pending, 2=Paid, 3=PartiallyPaid, 4=Overdue, 5=Cancelled, 6=Rescheduled
    public bool IsPaid { get => InstallmentStatus == 2; set { if (value) InstallmentStatus = 2; } }
    
    // Late Penalties Tracking
    public bool IsLate { get; set; }
    public int? LateDays { get; set; }
    public decimal? LateFeePercentage { get; set; }
    public decimal? LateFeeAmount { get; set; }
    public bool LateFeePaid { get; set; }
    public DateTime? LateFeePaymentDate { get; set; }
    public string? LateFeePaymentReference { get; set; }
    
    // Rescheduling & Waiver Audit
    public bool IsRescheduled { get; set; }
    public DateTime? RescheduledDate { get; set; }
    public long? RescheduledByUserId { get; set; }
    public string? RescheduledReason { get; set; }
    public DateTime? NewDueDate { get; set; }
    
    public bool IsWaived { get; set; }
    public string? WaiverReason { get; set; }
    public DateTime? WaiverDate { get; set; }
    public long? WaivedByUserId { get; set; }
    public string? WaiverApprovalDocumentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual StudentInvoice? Invoice { get; set; }
}

/// <summary>
/// سند دفع الرسوم - Payment record extracted from ZIP ERD Payment table.
/// </summary>
public class FeePayment : BaseAuditableEntity
{
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? InvoiceId { get; set; }
    public long? InstallmentId { get; set; }
    
    public string PaymentNumber { get; set; } = string.Empty; // رقم سند الدفع فريد
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public DateTime? PaymentTime { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountPaid { get => Amount; set => Amount = value; }
    public string Currency { get; set; } = "SAR";
    public decimal ExchangeRate { get; set; } = 1.0m;
    public decimal ConvertedAmount { get; set; }
    
    public int PaymentMethod { get; set; } // 1=Cash, 2=BankTransfer, 3=Cheque, 4=OnlinePortal, 5=POSTerminal, 6=EWallet
    public string? PaymentType { get; set; } // Tuition, Installment, LateFee, Donation, Other
    
    // Banking & Electronic Instrument Reference
    public string? BankName { get; set; }
    public string? BankTransactionId { get; set; }
    public string? BankTransactionRef { get => BankTransactionId; set => BankTransactionId = value; }
    public string? CheckNumber { get; set; }
    public string? ChequeNumber { get => CheckNumber; set => CheckNumber = value; }
    public string? CheckBank { get; set; }
    public DateTime? CheckDate { get; set; }
    public string? CreditCardLast4 { get; set; }
    public string? CreditCardType { get; set; }
    public string? WalletType { get; set; }
    
    // Payer Identification & Receipt
    public string? PayerName { get; set; }
    public string? PayerType { get; set; } // Parent, Student, External
    public string? PayerEmail { get; set; }
    public string ReceiptNumber { get; set; } = string.Empty;
    public bool ReceiptPrinted { get; set; }
    public bool ReceiptSentToEmail { get; set; }
    public DateTime? ReceiptEmailSentAt { get; set; }
    public string? ReceiptDocumentUrl { get; set; }
    
    // Status, Confirmation & Reversal
    public int PaymentStatus { get; set; } = 1; // 1=Pending, 2=Confirmed, 3=Cancelled, 4=Failed, 5=Reversed
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public long? ConfirmedByUserId { get; set; }
    public long? CollectedByUserId { get => ConfirmedByUserId; set => ConfirmedByUserId = value; }
    public bool IsReversed { get; set; }
    public DateTime? ReversalDate { get; set; }
    public string? ReversalReason { get; set; }
    
    // Allocations Breakdown JSON
    public string? AllocatedInvoicesJson { get; set; } // { invoiceId: allocatedAmount }
    public string? AllocatedItemsJson { get; set; } // { itemId: allocatedAmount }
    public string? Notes { get; set; }

    public virtual StudentAccount? StudentAccount { get; set; }
}
