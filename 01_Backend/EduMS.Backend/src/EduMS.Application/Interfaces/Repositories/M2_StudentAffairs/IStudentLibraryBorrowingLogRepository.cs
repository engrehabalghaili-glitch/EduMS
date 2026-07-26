using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Domain.Entities;
using EduMS.Application.Interfaces.Repositories.Common;

namespace EduMS.Application.Interfaces.Repositories.M2_StudentAffairs;

public interface IStudentLibraryBorrowingLogRepository : IGenericRepository<StudentLibraryBorrowingLog>
{
    // 1. الفلترة والتصنيف (Filtering and Categorization)
    // جلب سجلات الاستعارة بناءً على حالة الاستعارة (نشطة، مرجعة، متأخرة)
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetBorrowingLogsByStatusAsync(int borrowingStatus, CancellationToken cancellationToken = default);
    
    // جلب السجلات التي عليها غرامات تأخير ولم تُدفع بعد
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetLogsWithUnpaidPenaltiesAsync(CancellationToken cancellationToken = default);
    
    // جلب الكتب المستعارة التي تجاوزت تاريخ الاستحقاق ولم تُرجع
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetOverdueBorrowingLogsAsync(DateTime currentDate, CancellationToken cancellationToken = default);

    // 2. الاستعلام عبر المفاتيح الأجنبية (Foreign Keys)
    // جلب سجل الاستعارة لطالب محدد
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetBorrowingLogsByStudentIdAsync(long studentId, CancellationToken cancellationToken = default);
    
    // جلب سجل إعارات كتاب/عنصر معين في المكتبة
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetBorrowingLogsByLibraryItemIdAsync(long libraryItemId, CancellationToken cancellationToken = default);
    
    // جلب الإعارات التي قام بتسجيلها أمين مكتبة محدد
    Task<IEnumerable<StudentLibraryBorrowingLog>> GetBorrowingLogsIssuedByLibrarianAsync(long librarianEmployeeId, CancellationToken cancellationToken = default);
}
