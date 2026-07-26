using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IAppointmentDecisionRepository : IGenericRepository<AppointmentDecision>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب القرارات بناءً على نوع القرار (تعيين جديد، ترقية، تمديد، نقل)
    Task<IEnumerable<AppointmentDecision>> GetDecisionsByTypeAsync(int decisionType, CancellationToken cancellationToken = default);
    
    // جلب القرارات بناءً على مصدرها (وزارة، إدارة، مدرسة)
    Task<IEnumerable<AppointmentDecision>> GetDecisionsBySourceAsync(int decisionSource, CancellationToken cancellationToken = default);
    
    // جلب القرارات الصادرة في فترة زمنية محددة
    Task<IEnumerable<AppointmentDecision>> GetDecisionsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة قرارات التعيين الخاصة بموظف محدد
    Task<IEnumerable<AppointmentDecision>> GetDecisionsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب القرارات المرتبطة بقسم محدد
    Task<IEnumerable<AppointmentDecision>> GetDecisionsByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
}
