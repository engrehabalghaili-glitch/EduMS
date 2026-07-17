using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IClassSectionRepository : IGenericRepository<ClassSection>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // نمرر excludeId لتجاهل الشعبة الحالية عند التعديل
    Task<bool> IsSectionCodeUniqueAsync(string sectionCode, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة بالحالة (Status Filters)
    // جلب جميع الشعب الفعالة (غير المغلقة أو المدمجة)
    Task<IEnumerable<ClassSection>> GetActiveSectionsAsync(CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب جميع الشعب التابعة لمدرسة معينة
    Task<IEnumerable<ClassSection>> GetSectionsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب الشعب التابعة لسنة أكاديمية محددة
    Task<IEnumerable<ClassSection>> GetSectionsByAcademicYearIdAsync(long academicYearId, CancellationToken cancellationToken = default);
    
    // جلب الشعب المخصصة لغرفة صفية معينة (مكانيًا)
    Task<IEnumerable<ClassSection>> GetSectionsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب الشعب التابعة لسعة مرحلة دراسية معينة
    Task<IEnumerable<ClassSection>> GetSectionsByGradeCapacityIdAsync(long gradeCapacityId, CancellationToken cancellationToken = default);
    
    // جلب الشعب التي يكون فيها موظف معين هو رائد/مربي الصف
    Task<IEnumerable<ClassSection>> GetSectionsByHomeroomTeacherIdAsync(long employeeId, CancellationToken cancellationToken = default);
}
