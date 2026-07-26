using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;

namespace EduMS.Application.Interfaces.Repositories.M5_FinancialManagement;

public interface IFeeTypeRepository : IGenericRepository<FeeType>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب أنواع الرسوم الفعالة
    Task<IEnumerable<FeeType>> GetActiveFeeTypesAsync(CancellationToken cancellationToken = default);
    
    // جلب أنواع الرسوم الإلزامية
    Task<IEnumerable<FeeType>> GetMandatoryFeeTypesAsync(CancellationToken cancellationToken = default);
    
    // جلب أنواع الرسوم بناءً على تصنيفها (رسوم دراسية، باص، زي، كتب، الخ)
    Task<IEnumerable<FeeType>> GetFeeTypesByCategoryAsync(int feeCategory, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب أنواع الرسوم المطبقة في مدرسة معينة
    Task<IEnumerable<FeeType>> GetFeeTypesBySchoolIdAsync(long schoolId, CancellationToken cancellationToken = default);
    
    // 3. التحقق (Validation)
    // التأكد من عدم تكرار كود نوع الرسوم
    Task<bool> IsFeeCodeUniqueAsync(string feeCode, long? excludeId = null, CancellationToken cancellationToken = default);
}
