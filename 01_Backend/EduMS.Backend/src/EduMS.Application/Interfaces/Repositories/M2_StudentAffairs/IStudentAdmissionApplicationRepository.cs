using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentAdmissionApplicationRepository : IGenericRepository<StudentAdmissionApplication>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب طلبات القبول بناءً على حالتها (قيد المراجعة، مقبول، مرفوض)
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsByStatusAsync(int requestStatus, CancellationToken cancellationToken = default);
    
    // جلب طلبات القبول المقدمة خلال فترة زمنية محددة
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsBySubmissionDateAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    // جلب طلبات القبول للطلاب ذوي الاحتياجات الخاصة لدراستها بعناية
    Task<IEnumerable<StudentAdmissionApplication>> GetSpecialNeedsApplicationsAsync(CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب طلبات القبول المرفوعة من قبل ولي أمر معين
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsByGuardianIdAsync(long guardianId, CancellationToken cancellationToken = default);
    
    // جلب طلبات القبول الخاصة بمدرسة محددة
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب طلبات القبول لسنة أكاديمية محددة
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsByAcademicYearIdAsync(long academicYearId, CancellationToken cancellationToken = default);
    
    // جلب طلبات القبول التي تمت مراجعتها من قبل موظف محدد
    Task<IEnumerable<StudentAdmissionApplication>> GetApplicationsReviewedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
