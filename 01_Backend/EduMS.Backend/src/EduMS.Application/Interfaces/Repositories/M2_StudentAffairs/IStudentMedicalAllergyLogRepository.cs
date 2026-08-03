using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentMedicalAllergyLogRepository : IGenericRepository<StudentMedicalAllergyLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الحساسية بناءً على مستوى الخطورة (طفيف، متوسط، مهدد للحياة)
    Task<IEnumerable<StudentMedicalAllergyLog>> GetAllergiesBySeverityAsync(int severityLevel, CancellationToken cancellationToken = default);
    
    // جلب الطلاب الذين يحتاجون إلى حقنة الإبينفرين (EpiPen) في حالات الطوارئ
    Task<IEnumerable<StudentMedicalAllergyLog>> GetEpiPenRequiredAllergiesAsync(CancellationToken cancellationToken = default);
    
    // جلب سجلات الحساسية بناءً على حالة التحقق من قبل الممرضة
    Task<IEnumerable<StudentMedicalAllergyLog>> GetAllergiesByVerificationStatusAsync(int verificationStatus, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة سجلات الحساسية الطبية الخاصة بطالب محدد
    Task<IEnumerable<StudentMedicalAllergyLog>> GetAllergiesByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
}
