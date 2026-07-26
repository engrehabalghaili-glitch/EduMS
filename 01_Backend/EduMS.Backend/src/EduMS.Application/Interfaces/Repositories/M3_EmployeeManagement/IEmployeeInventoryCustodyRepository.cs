using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeInventoryCustodyRepository : IGenericRepository<EmployeeInventoryCustody>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات العهدة الفعالة (التي لم يتم إرجاعها بعد)
    Task<IEnumerable<EmployeeInventoryCustody>> GetActiveCustodiesAsync(CancellationToken cancellationToken = default);
    
    // جلب العهد التي تم إرجاعها وتوجد عليها غرامة أو تلفيات
    Task<IEnumerable<EmployeeInventoryCustody>> GetCustodiesWithDamagesOrPenaltiesAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات العهدة بناءً على حالة العهدة (نشط، مرجع، مفقود، تالف)
    Task<IEnumerable<EmployeeInventoryCustody>> GetCustodiesByStatusAsync(int custodyStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة العهد المسجلة على موظف محدد
    Task<IEnumerable<EmployeeInventoryCustody>> GetCustodiesByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب العهد المتعلقة بأصل مدرسي معين (مثل جهاز محدد)
    Task<IEnumerable<EmployeeInventoryCustody>> GetCustodiesByAssetIdAsync(long assetId, CancellationToken cancellationToken = default);
}
