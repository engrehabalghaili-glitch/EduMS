using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;
using EduMS.Domain.Entities;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.M1_SchoolAdmin;

public class SchoolRepository(EduMSDbContext dbContext) : Repository<School>(dbContext), ISchoolRepository
{
    public async Task<bool> IsSchoolCodeUniqueAsync(string schoolCode, long? excludeId = null, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<School>().Where(s => s.SchoolCode == schoolCode && !s.IsDeleted);
        if (excludeId.HasValue)
        {
            query = query.Where(s => s.Id != excludeId.Value);
        }
        return !await query.AnyAsync(cancellationToken);
    }

    public async Task<IEnumerable<School>> GetActiveSchoolsAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<School>()
            .Where(s => s.IsActive && !s.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<School>> GetSchoolsByDirectorateIdAsync(long directorateId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<School>()
            .Where(s => s.DirectorateId == directorateId && !s.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<School>> GetSchoolsByEducationalStageIdAsync(long educationalStageId, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<School>()
            .Where(s => s.EducationalStageId == educationalStageId && !s.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<School>> SearchSchoolsByNameAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetActiveSchoolsAsync(cancellationToken);
        }

        var lowerTerm = searchTerm.Trim().ToLower();
        return await DbContext.Set<School>()
            .Where(s => !s.IsDeleted && (s.SchoolNameAr.Contains(searchTerm) || s.SchoolNameEn.ToLower().Contains(lowerTerm) || s.SchoolCode.ToLower().Contains(lowerTerm)))
            .ToListAsync(cancellationToken);
    }
}
