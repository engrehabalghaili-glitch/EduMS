namespace EduMS.Application.Students.Queries;

public record StudentEnrollmentSummaryDto(
    long StudentId,
    string FullNameAr,
    string FullNameEn,
    string NationalId,
    int Gender,
    string EnrollmentNumber,
    DateTime EnrollmentDate,
    long? SchoolId,
    string? SchoolNameAr,
    long? GuardianId,
    string? GuardianNameAr,
    bool IsActive
);
