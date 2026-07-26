using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentAttachmentRepository : IGenericRepository<StudentAttachment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب المرفقات الخاصة بالطلاب بناءً على فئة المرفق (شهادة طبية، كشف درجات، الخ)
    Task<IEnumerable<StudentAttachment>> GetAttachmentsByCategoryAsync(int attachmentCategory, CancellationToken cancellationToken = default);
    
    // جلب المرفقات السرية فقط (أو غير السرية)
    Task<IEnumerable<StudentAttachment>> GetConfidentialAttachmentsAsync(bool isConfidential, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة المرفقات والمستندات المرتبطة بطالب محدد
    Task<IEnumerable<StudentAttachment>> GetAttachmentsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب المرفقات التي قام برفعها موظف محدد
    Task<IEnumerable<StudentAttachment>> GetAttachmentsUploadedByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
