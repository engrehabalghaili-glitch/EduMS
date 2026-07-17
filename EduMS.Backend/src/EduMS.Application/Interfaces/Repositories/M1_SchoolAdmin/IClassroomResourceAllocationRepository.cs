using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IClassroomResourceAllocationRepository : IGenericRepository<ClassroomResourceAllocation>
{
    // 1. Inventory Helpers
    // جلب الموارد المخصصة لفصل دراسي معين
    Task<IEnumerable<ClassroomResourceAllocation>> GetResourcesByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب الموارد حسب نوعها داخل الفصل (مثلاً: أجهزة عرض، سبورات ذكية، أجهزة تكييف)
    Task<IEnumerable<ClassroomResourceAllocation>> GetResourcesByTypeAsync(long classroomId, int resourceType, CancellationToken cancellationToken = default);
    
    // 2. Maintenance Tracking
    // جلب الموارد التي اقترب موعد صيانتها (NextMaintenanceDate)
    Task<IEnumerable<ClassroomResourceAllocation>> GetResourcesDueForMaintenanceAsync(long classroomId, int daysThreshold, CancellationToken cancellationToken = default);
}



