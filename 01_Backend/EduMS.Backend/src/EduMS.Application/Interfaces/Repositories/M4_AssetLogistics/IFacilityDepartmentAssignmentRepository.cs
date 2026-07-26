using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IFacilityDepartmentAssignmentRepository : IGenericRepository<FacilityDepartmentAssignment>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب التخصيصات الفعالة للمرافق
    Task<IEnumerable<FacilityDepartmentAssignment>> GetActiveAssignmentsAsync(CancellationToken cancellationToken = default);
    
    // جلب المرافق المشتركة بين عدة أقسام
    Task<IEnumerable<FacilityDepartmentAssignment>> GetSharedFacilitiesAsync(CancellationToken cancellationToken = default);
    
    // جلب تخصيصات المرافق حسب نوع المرفق (فصل، معمل، مكتبة، الخ)
    Task<IEnumerable<FacilityDepartmentAssignment>> GetAssignmentsByFacilityTypeAsync(int facilityType, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة المرافق المخصصة لقسم محدد
    Task<IEnumerable<FacilityDepartmentAssignment>> GetAssignmentsByDepartmentIdAsync(long departmentId, CancellationToken cancellationToken = default);
    
    // جلب تخصيصات مرفق محدد لمعرفة الأقسام المستفيدة منه
    Task<IEnumerable<FacilityDepartmentAssignment>> GetAssignmentsByFacilityIdAsync(long facilityId, CancellationToken cancellationToken = default);
    
    // جلب تخصيصات المرافق في مدرسة محددة
    Task<IEnumerable<FacilityDepartmentAssignment>> GetAssignmentsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
}
