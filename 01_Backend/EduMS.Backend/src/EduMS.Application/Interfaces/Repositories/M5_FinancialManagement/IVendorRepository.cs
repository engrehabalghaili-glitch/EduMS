using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IVendorRepository : IGenericRepository<Vendor>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الموردين الفعالين في النظام
    Task<IEnumerable<Vendor>> GetActiveVendorsAsync(CancellationToken cancellationToken = default);
    
    // 2. التحقق (Validation)
    // التأكد من عدم تكرار الرقم الضريبي للمورد
    Task<bool> IsTaxNumberUniqueAsync(string taxNumber, long? excludeId = null, CancellationToken cancellationToken = default);
}
