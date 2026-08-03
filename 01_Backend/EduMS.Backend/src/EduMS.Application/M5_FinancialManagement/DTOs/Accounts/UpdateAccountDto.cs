using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.Accounts;

public class UpdateAccountDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string AccountCode { get; set; } = string.Empty;
    public string AccountNameAr { get; set; } = string.Empty;
    public string AccountNameEn { get; set; } = string.Empty;
    public long? ParentAccountId { get; set; }
    public int AccountType { get; set; }
    public int LevelNumber { get; set; }
    public decimal CurrentBalance { get; set; }
    public bool IsActive { get; set; } = true;
}
