using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Students.Commands;

public record EnrollStudentCommand(
    string FullNameAr,
    string FullNameEn,
    string NationalId,
    int Gender,
    string EnrollmentNumber,
    DateTime EnrollmentDate,
    long SchoolId,
    long? GuardianId
) : ICommand<long>;
