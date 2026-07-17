using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M4_AssetLogistics;

public interface IAssetAllocationRepository : IGenericRepository<AssetAllocation>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب تخصيصات الأصول الفعالة (التي لم يتم إرجاعها أو إتلافها)
    Task<IEnumerable<AssetAllocation>> GetActiveAllocationsAsync(CancellationToken cancellationToken = default);
    
    // جلب التخصيصات بناءً على حالة التخصيص (نشط، مرجع، تالف)
    Task<IEnumerable<AssetAllocation>> GetAllocationsByStatusAsync(string status, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب التخصيصات لمدرسة محددة
    Task<IEnumerable<AssetAllocation>> GetAllocationsBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // جلب التخصيصات لغرفة صفية محددة
    Task<IEnumerable<AssetAllocation>> GetAllocationsByClassroomIdAsync(long classroomId, CancellationToken cancellationToken = default);
    
    // جلب التخصيصات المسندة لموظف محدد
    Task<IEnumerable<AssetAllocation>> GetAllocationsByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    
    // جلب جميع التخصيصات لصنف مستودعي محدد (InventoryItem)
    Task<IEnumerable<AssetAllocation>> GetAllocationsByInventoryItemIdAsync(long inventoryItemId, CancellationToken cancellationToken = default);
}
