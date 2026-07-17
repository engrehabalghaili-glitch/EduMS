using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentFinancialAidApplicationRepository : IGenericRepository<StudentFinancialAidApplication>
{
    // 1. التحقق من التكرار (Unique Constraints)
    // التأكد من عدم تكرار الرقم المرجعي لطلب المساعدة المالية
    Task<bool> IsApplicationReferenceNumberUniqueAsync(string referenceNumber, long? excludeId = null, CancellationToken cancellationToken = default);

    // 2. الفلترة والتصنيف (Filtering and Categorization)
    // جلب الطلبات بناءً على حالة الطلب (قيد المراجعة، مقبول، مرفوض)
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsByStatusAsync(int applicationStatus, CancellationToken cancellationToken = default);
    
    // جلب الطلبات بناءً على فئة المساعدة (دعم أيتام، منحة تفوق، خصم أبناء عاملين)
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsByAidCategoryAsync(int aidCategory, CancellationToken cancellationToken = default);
    
    // جلب الطلبات المقدمة خلال فترة زمنية محددة
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    // 3. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات المساعدة المالية المرتبطة بطالب محدد
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب طلبات المساعدة المالية المرفوعة من قبل ولي أمر محدد
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsByGuardianIdAsync(long guardianId, CancellationToken cancellationToken = default);
    
    // جلب الطلبات التي قامت لجنة أو موظف محدد بمراجعتها
    Task<IEnumerable<StudentFinancialAidApplication>> GetApplicationsReviewedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
