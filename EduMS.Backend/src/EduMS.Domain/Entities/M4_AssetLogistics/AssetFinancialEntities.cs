using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// القيم المالية الكاملة للأصل - extracted from ZIP ERD AssetFinancials (lines 7195-7216).
/// </summary>
public class AssetFinancials : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal ShippingCosts { get; set; }
    public decimal CustomsFees { get; set; }
    public decimal InstallationCosts { get; set; }
    public decimal OtherCosts { get; set; }
    public decimal TotalInitialCost { get; set; }
    public string? Currency { get; set; }
    public decimal ExchangeRateToSar { get; set; } = 1;
    public decimal SalvageValue { get; set; }
    public DateTime? ResidualValueLastUpdate { get; set; }
    public string? FiscalYear { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// سياسة إهلاك الأصل - extracted from ZIP ERD AssetDepreciation (lines 7218-7239).
/// </summary>
public class AssetDepreciation : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int MethodType { get; set; } // 1=StraightLine, 2=DecliningBalance, 3=UnitsOfProduction
    public int UsefulLifeYears { get; set; }
    public decimal DepreciationRate { get; set; }
    public decimal CurrentBookValue { get; set; }
    public decimal AccumulatedDepreciation { get; set; }
    public decimal NetBookValue { get; set; }
    public decimal DepreciableAmount { get; set; }
    public DateTime? LastDepreciationDate { get; set; }
    public string? LastDepreciationPeriod { get; set; }
    public bool IsFullyDepreciated { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// قسط الإهلاك الدوري المسجل - extracted from ZIP ERD DepreciationTransactions (lines 7241-7263).
/// </summary>
public class DepreciationTransaction : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public long? DepreciationPolicyId { get; set; }
    public string PeriodStart { get; set; } = string.Empty;
    public string PeriodEnd { get; set; } = string.Empty;
    public int PeriodType { get; set; } // 1=Monthly, 2=Quarterly, 3=SemiAnnual, 4=Annual
    public string FiscalYear { get; set; } = string.Empty;
    public int PeriodNumber { get; set; }
    public decimal DepreciationAmount { get; set; }
    public decimal AccumulatedDepreciationAfter { get; set; }
    public decimal NetBookValueAfter { get; set; }
    public bool IsPostedToLedger { get; set; }
    public string? LedgerEntryReference { get; set; }
    public DateTime? PostedToLedgerDate { get; set; }
    public long? CalculatedByUserId { get; set; }
    public DateTime? CalculationDate { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// إعادة تقييم أو انخفاض قيمة الأصل - extracted from ZIP ERD RevaluationImpairment (lines 7265-7294).
/// </summary>
public class AssetRevaluationImpairment : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int OperationType { get; set; } // 1=Revaluation, 2=Impairment
    public DateTime EffectiveDate { get; set; }
    public decimal OldBookValue { get; set; }
    public decimal OldAccumulatedDepreciation { get; set; }
    public decimal OldNetBookValue { get; set; }
    public decimal NewValue { get; set; }
    public decimal NewNetBookValue { get; set; }
    public decimal DifferenceAmount { get; set; }
    public int DifferenceType { get; set; } // 1=RevaluationGain, 2=RevaluationLoss
    public string? ValuationFirmName { get; set; }
    public string? ValuationReportNumber { get; set; }
    public DateTime? ValuationReportDate { get; set; }
    public string? Reason { get; set; }
    public string? AttachmentUrl { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int OperationStatus { get; set; } = 1; // 1=Draft, 2=Approved, 3=Posted
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// المصروفات على الأصل (رأسمالية أو تشغيلية) - extracted from ZIP ERD AssetExpenses (lines 7296-7318).
/// </summary>
public class AssetExpense : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int ExpenseType { get; set; } // 1=Capex, 2=Opex
    public DateTime ExpenseDate { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public string? Description { get; set; }
    public long? RelatedMaintenanceExecutionId { get; set; }
    public bool IsCapitalized { get; set; }
    public DateTime? CapitalizationDate { get; set; }
    public bool AccountedInFinancials { get; set; }
    public bool AccountedInDepreciation { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}
