using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M3_EmployeeManagement;

public interface IVacantPositionRepository : IGenericRepository<VacantPosition>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الوظائف الشاغرة بناءً على حالتها (مفتوحة، مغلقة، قيد الانتظار)
    Task<IEnumerable<VacantPosition>> GetVacanciesByStatusAsync(int vacancyStatus, CancellationToken cancellationToken = default);
    
    // جلب الوظائف الشاغرة الفعالة حالياً
    Task<IEnumerable<VacantPosition>> GetActiveVacanciesAsync(DateTime currentDate, CancellationToken cancellationToken = default);
    
    // جلب الوظائف بناءً على نوع الموظف المطلوب (معلم، إداري، فني)
    Task<IEnumerable<VacantPosition>> GetVacanciesByEmployeeTypeAsync(int employeeType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب الشواغر الوظيفية في مدرسة محددة
    Task<IEnumerable<VacantPosition>> GetVacanciesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الشواغر في قطاع تنظيمي محدد
    Task<IEnumerable<VacantPosition>> GetVacanciesBySectorIdAsync(long sectorId, CancellationToken cancellationToken = default);
    
    // جلب الشواغر التابعة لقسم محدد
    Task<IEnumerable<VacantPosition>> GetVacanciesByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
}
