using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentGuardianRelationshipRepository : IGenericRepository<StudentGuardianRelationship>
{
    // 1. الفلترة والتصنيف (Filtering and Flags)
    // جلب جهات الاتصال الأساسية لطالب معين
    Task<IEnumerable<StudentGuardianRelationship>> GetPrimaryContactsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب جهات اتصال الطوارئ لطالب معين
    Task<IEnumerable<StudentGuardianRelationship>> GetEmergencyContactsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب الأشخاص المسؤولين مالياً عن طالب معين
    Task<IEnumerable<StudentGuardianRelationship>> GetFinancialSponsorsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة العلاقات المرتبطة بطالب محدد
    Task<IEnumerable<StudentGuardianRelationship>> GetRelationshipsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب كافة الطلاب المرتبطين بولي أمر محدد
    Task<IEnumerable<StudentGuardianRelationship>> GetRelationshipsByGuardianIdAsync(long guardianId, CancellationToken cancellationToken = default);
}
