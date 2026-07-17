using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IFeeStructureRepository : IGenericRepository<FeeStructure>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب هياكل الرسوم بناءً على السنة الأكاديمية
    Task<IEnumerable<FeeStructure>> GetFeeStructuresByAcademicYearAsync(string academicYear, CancellationToken cancellationToken = default);
    
    // جلب هياكل الرسوم بناءً على المستوى الدراسي (GradeLevel)
    Task<IEnumerable<FeeStructure>> GetFeeStructuresByGradeLevelAsync(int gradeLevel, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب هياكل الرسوم التابعة لمدرسة محددة
    Task<IEnumerable<FeeStructure>> GetFeeStructuresBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
