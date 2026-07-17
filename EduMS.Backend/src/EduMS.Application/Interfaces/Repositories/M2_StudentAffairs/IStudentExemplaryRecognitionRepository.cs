using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentExemplaryRecognitionRepository : IGenericRepository<StudentExemplaryRecognition>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التكريمات بناءً على الفئة (تفوق أكاديمي، سلوكي، مسابقات)
    Task<IEnumerable<StudentExemplaryRecognition>> GetRecognitionsByCategoryAsync(int category, CancellationToken cancellationToken = default);
    
    // جلب التكريمات التي مُنحت خلال فترة زمنية محددة
    Task<IEnumerable<StudentExemplaryRecognition>> GetRecognitionsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب التكريمات المميزة التي تم عرضها في لوحة الشرف المدرسية
    Task<IEnumerable<StudentExemplaryRecognition>> GetFeaturedRecognitionsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية والزمنية (Foreign Keys & Term)
    // جلب كافة سجلات التكريم الخاصة بطالب محدد
    Task<IEnumerable<StudentExemplaryRecognition>> GetRecognitionsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب سجلات التكريم لجميع الطلاب في سنة أكاديمية محددة
    Task<IEnumerable<StudentExemplaryRecognition>> GetRecognitionsByAcademicYearAsync(string academicYear, CancellationToken cancellationToken = default);
}
