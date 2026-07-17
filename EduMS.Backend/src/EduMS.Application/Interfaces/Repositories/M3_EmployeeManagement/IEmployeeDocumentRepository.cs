using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeDocumentRepository : IGenericRepository<EmployeeDocument>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الوثائق المنتهية أو التي تقترب من الانتهاء
    Task<IEnumerable<EmployeeDocument>> GetExpiringDocumentsAsync(DateTime targetDate, CancellationToken cancellationToken = default);
    
    // جلب الوثائق بناءً على حالتها (مقبولة، مرفوضة، قيد المراجعة)
    Task<IEnumerable<EmployeeDocument>> GetDocumentsByStatusAsync(int documentStatus, CancellationToken cancellationToken = default);
    
    // جلب الوثائق غير المعتمدة (التي تحتاج للتحقق)
    Task<IEnumerable<EmployeeDocument>> GetUnverifiedDocumentsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة وثائق موظف محدد
    Task<IEnumerable<EmployeeDocument>> GetDocumentsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الوثائق بناءً على نوعها (جواز سفر، هوية، عقد)
    Task<IEnumerable<EmployeeDocument>> GetDocumentsByTypeAsync(long employeeId, string documentType, CancellationToken cancellationToken = default);
}
