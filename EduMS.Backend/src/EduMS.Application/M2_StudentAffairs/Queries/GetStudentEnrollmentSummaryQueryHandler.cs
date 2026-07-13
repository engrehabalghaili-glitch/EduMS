using EduMS.Application.Common.CQRS;
using EduMS.Domain.Entities;
using EduMS.Domain.Interfaces;

namespace EduMS.Application.Students.Queries;

public class GetStudentEnrollmentSummaryQueryHandler(
    IRepository<Student> studentRepository,
    IRepository<School> schoolRepository,
    IRepository<Guardian> guardianRepository
) : IQueryHandler<GetStudentEnrollmentSummaryQuery, StudentEnrollmentSummaryDto?>
{
    private readonly IRepository<Student> _studentRepository = studentRepository;
    private readonly IRepository<School> _schoolRepository = schoolRepository;
    private readonly IRepository<Guardian> _guardianRepository = guardianRepository;

    public async Task<StudentEnrollmentSummaryDto?> HandleAsync(GetStudentEnrollmentSummaryQuery request, CancellationToken cancellationToken)
    {
        var enrollmentNo = request.EnrollmentNumber.Trim().ToUpperInvariant();
        var students = await _studentRepository.FindAsync(s => s.EnrollmentNumber == enrollmentNo, cancellationToken);
        var student = students.FirstOrDefault();

        if (student == null) return null;

        string? schoolNameAr = null;
        if (student.SchoolId.HasValue && student.SchoolId.Value > 0)
        {
            var school = await _schoolRepository.GetByIdAsync(student.SchoolId.Value, cancellationToken);
            schoolNameAr = school?.SchoolNameAr;
        }

        string? guardianNameAr = null;
        if (student.GuardianId.HasValue && student.GuardianId.Value > 0)
        {
            var guardian = await _guardianRepository.GetByIdAsync(student.GuardianId.Value, cancellationToken);
            guardianNameAr = guardian?.FullNameAr;
        }

        return new StudentEnrollmentSummaryDto(
            student.Id,
            student.FullNameAr,
            student.FullNameEn,
            student.NationalId,
            (int)student.Gender,
            student.EnrollmentNumber,
            student.EnrollmentDate,
            student.SchoolId,
            schoolNameAr,
            student.GuardianId,
            guardianNameAr,
            student.IsActive
        );
    }
}
