using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Interfaces.CrossModule
{
    public interface IAcademicIntegrityChecker
    {
        Task<bool> HasIncompleteGradesAsync(long academicYearId, CancellationToken cancellationToken);
        Task<bool> HasOutstandingDuesAsync(long academicYearId, CancellationToken cancellationToken);
    }
}
