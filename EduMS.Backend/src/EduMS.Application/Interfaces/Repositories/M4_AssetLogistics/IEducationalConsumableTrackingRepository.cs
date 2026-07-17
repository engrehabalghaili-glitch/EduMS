using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IEducationalConsumableTrackingRepository : IGenericRepository<EducationalConsumableTracking>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب استهلاك المواد التعليمية ضمن فترة زمنية محددة
    Task<IEnumerable<EducationalConsumableTracking>> GetConsumablesByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب الاستهلاك بناءً على تصنيف المادة (حبر، ورق، مواد كيميائية، الخ)
    Task<IEnumerable<EducationalConsumableTracking>> GetConsumablesByCategoryAsync(string category, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب استهلاك المواد التعليمية في مدرسة محددة
    Task<IEnumerable<EducationalConsumableTracking>> GetConsumablesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب المواد المستهلكة من قبل قسم معين
    Task<IEnumerable<EducationalConsumableTracking>> GetConsumablesByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
    
    // جلب المواد المستهلكة لمادة دراسية محددة
    Task<IEnumerable<EducationalConsumableTracking>> GetConsumablesBySubjectIdAsync(long subjectId, CancellationToken cancellationToken = default);
}
