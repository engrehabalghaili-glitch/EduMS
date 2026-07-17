using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentInventoryCustodyRepository : IGenericRepository<StudentInventoryCustody>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب عهدة الطالب بناءً على نوع العنصر (كتاب، زي، جهاز)
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyByItemTypeAsync(int itemType, CancellationToken cancellationToken = default);
    
    // جلب العهد بناءً على حالة الإرجاع (مرجعة، تالفة، مفقودة)
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyByReturnStatusAsync(int conditionAtReturn, CancellationToken cancellationToken = default);
    
    // جلب السجلات التي تستحق دفع غرامة (تالف أو مفقود ولم تُدفع غرامته بعد)
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyWithPendingPenaltiesAsync(CancellationToken cancellationToken = default);
    
    // جلب عناصر العهدة التي لم يتم إرجاعها وتجاوزت تاريخ الإرجاع المتوقع
    Task<IEnumerable<StudentInventoryCustody>> GetOverdueCustodyAsync(DateTime currentDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب كافة عناصر العهدة المستلمة من قبل طالب محدد
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب عهدة الطالب خلال سنة أكاديمية محددة
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyByAcademicYearIdAsync(long academicYearId, CancellationToken cancellationToken = default);
    
    // جلب سجلات العهدة التي قام بتسليمها موظف/أمين مستودع محدد
    Task<IEnumerable<StudentInventoryCustody>> GetCustodyDeliveredByEmployeeAsync(long employeeId, CancellationToken cancellationToken = default);
}
