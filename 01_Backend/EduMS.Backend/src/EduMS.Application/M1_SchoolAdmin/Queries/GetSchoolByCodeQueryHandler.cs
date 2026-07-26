using EduMS.Application.Common.CQRS;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Application.Interfaces.Repositories.M1_SchoolAdmin;
using EduMS.Domain.Entities;

namespace EduMS.Application.Schools.Queries;

public class GetSchoolByCodeQueryHandler(
    ISchoolRepository schoolRepository,
    IGenericRepository<AcademicLockPeriod> lockRepository
) : IQueryHandler<GetSchoolByCodeQuery, SchoolDetailsDto?>
{
    private readonly ISchoolRepository _schoolRepository = schoolRepository;
    private readonly IGenericRepository<AcademicLockPeriod> _lockRepository = lockRepository;


    public async Task<SchoolDetailsDto?> HandleAsync(GetSchoolByCodeQuery request, CancellationToken cancellationToken)
    {
        var code = request.SchoolCode.Trim().ToUpperInvariant();
        var schools = await _schoolRepository.FindAsync(s => s.SchoolCode == code, cancellationToken);
        var school = schools.FirstOrDefault();

        if (school == null) return null;

        var now = DateTime.UtcNow;
        var locks = await _lockRepository.FindAsync(
            l => l.SchoolId == school.Id && l.IsActive && l.StartDate <= now && l.EndDate >= now,
            cancellationToken
        );

        var activeLock = locks.FirstOrDefault();

        return new SchoolDetailsDto(
            school.Id,
            school.SchoolNameAr,
            school.SchoolNameEn,
            school.SchoolCode,
            school.Directorate,
            school.Governorate,
            school.IsActive,
            activeLock != null,
            activeLock?.PeriodName
        );
    }
}
