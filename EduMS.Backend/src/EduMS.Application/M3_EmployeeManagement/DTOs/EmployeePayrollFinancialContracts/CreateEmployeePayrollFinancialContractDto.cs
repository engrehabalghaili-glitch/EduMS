using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrollFinancialContracts;

public class CreateEmployeePayrollFinancialContractDto
{
    public long EmployeePayrollId { get; set; }
    public long EmployeeId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string FinancialTransactionReferenceNumber { get; set; } = string.Empty;
    public string CostCenterCode { get; set; } = string.Empty;
    public string BudgetLineCode { get; set; } = string.Empty;
    public decimal TotalGrossAmount { get; set; }
    public decimal TotalDeductionsAmount { get; set; }
    public decimal NetDisbursementAmount { get; set; }
    public string Currency { get; set; } = "SAR";
    public int DisbursementStatus { get; set; } = 1;
    public DateTime? DisbursementDate { get; set; }
    public string? BankTransferReference { get; set; }
    public long? FinancialAuditorEmployeeId { get; set; }
    public string? FinancialAuditNotes { get; set; }
}
