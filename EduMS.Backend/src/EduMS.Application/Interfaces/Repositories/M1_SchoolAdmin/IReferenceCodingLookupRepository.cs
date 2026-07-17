using System.Threading;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;

public interface IReferenceCodingLookupRepository : IGenericRepository<ReferenceCodingLookup>
{
    // 1. Conflict Prevention
    // التأكد من عدم تكرار كود (CodeKey) داخل نفس النوع (CodeType)
    Task<bool> IsCodeKeyUniqueAsync(long? schoolId, string codeType, string codeKey, long? excludeId = null, CancellationToken cancellationToken = default);
    
    // 2. Global vs Local lookups
    // جلب الرموز المرجعية العامة (Global System Codes)
    Task<IEnumerable<ReferenceCodingLookup>> GetSystemCodesAsync(string codeType, CancellationToken cancellationToken = default);
    
    // جلب الرموز المرجعية الخاصة بمدرسة معينة مع دمجها بالرموز العامة (اختياري)
    Task<IEnumerable<ReferenceCodingLookup>> GetCodesForSchoolAsync(long schoolId, string codeType, bool includeSystemCodes = true, CancellationToken cancellationToken = default);
    
    // 3. Hierarchy 
    // جلب الرموز الفرعية (Child Codes) التابعة لرمز أب
    Task<IEnumerable<ReferenceCodingLookup>> GetChildCodesAsync(long parentCodeId, CancellationToken cancellationToken = default);
}



