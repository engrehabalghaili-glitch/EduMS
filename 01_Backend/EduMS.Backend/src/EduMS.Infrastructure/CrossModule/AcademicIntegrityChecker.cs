using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.CrossModule;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.CrossModule
{
    public class AcademicIntegrityChecker(EduMSDbContext dbContext) : IAcademicIntegrityChecker
    {
        private readonly EduMSDbContext _dbContext = dbContext;

        public async Task<bool> HasIncompleteGradesAsync(long academicYearId, CancellationToken cancellationToken)
        {
            var academicYear = await _dbContext.Set<Domain.Entities.SchoolAcademicYear>()
                .FirstOrDefaultAsync(ay => ay.Id == academicYearId, cancellationToken);

            if (academicYear == null) return false;

            // Simplified check: Are there any assessments in this date range that don't have a passing/failing score or letter code?
            var hasIncomplete = await _dbContext.Set<Domain.Entities.StudentAssessment>()
                .AnyAsync(sa => sa.AssessmentDate >= academicYear.StartDate 
                             && sa.AssessmentDate <= academicYear.EndDate 
                             && string.IsNullOrEmpty(sa.LetterCodeResult), cancellationToken);

            return hasIncomplete;
        }

        public async Task<bool> HasOutstandingDuesAsync(long academicYearId, CancellationToken cancellationToken)
        {
            var academicYear = await _dbContext.Set<Domain.Entities.SchoolAcademicYear>()
                .FirstOrDefaultAsync(ay => ay.Id == academicYearId, cancellationToken);

            if (academicYear == null) return false;

            // Check if there are any unpaid invoices linked to fee structures for this academic year code
            var hasUnpaid = await _dbContext.Set<Domain.Entities.FeeInvoice>()
                .AnyAsync(fi => fi.FeeStructure != null && fi.FeeStructure.AcademicYear == academicYear.YearCode 
                             && fi.Status != 3, // Assuming 3 = Paid
                    cancellationToken);

            return hasUnpaid;
        }
    }
}
