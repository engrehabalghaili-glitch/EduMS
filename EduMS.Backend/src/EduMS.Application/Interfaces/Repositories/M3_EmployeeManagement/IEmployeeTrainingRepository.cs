using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IEmployeeTrainingRepository : IGenericRepository<EmployeeTraining>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الدورات التدريبية بناءً على حالتها (مسجل، قيد التنفيذ، مكتمل، ملغى)
    Task<IEnumerable<EmployeeTraining>> GetTrainingsByCompletionStatusAsync(int completionStatus, CancellationToken cancellationToken = default);
    
    // جلب الدورات التدريبية بناءً على نوعها (داخلي، خارجي، أونلاين، الخ)
    Task<IEnumerable<EmployeeTraining>> GetTrainingsByTypeAsync(int trainingType, CancellationToken cancellationToken = default);
    
    // جلب الدورات التدريبية التي تقع ضمن فترة زمنية محددة
    Task<IEnumerable<EmployeeTraining>> GetTrainingsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة الدورات التدريبية الخاصة بموظف محدد
    Task<IEnumerable<EmployeeTraining>> GetTrainingsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب الدورات التدريبية الخاصة بمدرسة معينة
    Task<IEnumerable<EmployeeTraining>> GetTrainingsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
