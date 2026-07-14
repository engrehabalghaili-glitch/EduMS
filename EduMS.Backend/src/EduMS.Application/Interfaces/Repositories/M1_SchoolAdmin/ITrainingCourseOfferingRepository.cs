using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface ITrainingCourseOfferingRepository : IGenericRepository<TrainingCourseOffering>
{
    // 1. Unique Constraints
    Task<bool> IsCourseCodeUniqueAsync(string courseCode, long? excludeId = null);
    
    // 2. Status Filters
    // جلب الدورات المتاحة للتسجيل حالياً (النشطة)
    Task<IEnumerable<TrainingCourseOffering>> GetActiveCoursesAsync();
    
    // 3. Search and Filtering
    // البحث باسم الدورة أو المدرب
    Task<IEnumerable<TrainingCourseOffering>> SearchCoursesAsync(string searchTerm);
    
    // جلب الدورات المرتبطة بمديرية معينة
    Task<IEnumerable<TrainingCourseOffering>> GetCoursesByDirectorateIdAsync(long directorateId);
    
    // جلب الدورات المرتبطة بمدرسة معينة
    Task<IEnumerable<TrainingCourseOffering>> GetCoursesBySchoolIdAsync(long schoolId);
}

