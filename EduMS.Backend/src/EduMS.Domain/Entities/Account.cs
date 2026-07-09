using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Account : BaseAuditableEntity
{
    public string AccountCode { get; set; } = string.Empty;
    public string AccountNameAr { get; set; } = string.Empty;
    public string AccountNameEn { get; set; } = string.Empty;
    public long? ParentAccountId { get; set; }
    public int AccountType { get; set; } // 1=Assets, 2=Liabilities, 3=Equity, 4=Revenues, 5=Expenses
    public int LevelNumber { get; set; } // level 1 to 5
    public decimal CurrentBalance { get; set; }
    public bool IsActive { get; set; } = true;

    // Self-referencing navigation properties
    public Account? ParentAccount { get; set; }
    public ICollection<Account> ChildAccounts { get; set; } = new List<Account>();
}
