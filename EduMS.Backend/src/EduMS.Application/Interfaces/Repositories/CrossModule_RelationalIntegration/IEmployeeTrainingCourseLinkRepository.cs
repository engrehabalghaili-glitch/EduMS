using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.CrossModule_RelationalIntegration;

public interface IEmployeeTrainingCourseLinkRepository : IGenericRepository<EmployeeTrainingCourseLink>
{
    // 1. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب تفاصيل دورات الموظف بناءً على سجل التدريب الفردي له
    Task<IEnumerable<EmployeeTrainingCourseLink>> GetLinksByEmployeeTrainingIdAsync(long employeeTrainingId, CancellationToken cancellationToken = default);
    
    // جلب جميع الموظفين الذين تم ربطهم بدورة تدريبية محددة
    Task<IEnumerable<EmployeeTrainingCourseLink>> GetLinksByTrainingCourseOfferingIdAsync(long trainingCourseOfferingId, CancellationToken cancellationToken = default);
    
    // جلب جميع الدورات التي حضرها موظف محدد
    Task<IEnumerable<EmployeeTrainingCourseLink>> GetLinksByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
}
