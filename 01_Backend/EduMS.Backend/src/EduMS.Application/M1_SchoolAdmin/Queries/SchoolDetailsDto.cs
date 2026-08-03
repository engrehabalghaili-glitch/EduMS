namespace EduMS.Application.Schools.Queries;

public record SchoolDetailsDto(
    long SchoolId,
    string SchoolNameAr,
    string SchoolNameEn,
    string SchoolCode,
    string Directorate,
    string Governorate,
    bool IsActive,
    bool IsCurrentlyLocked,
    string? ActiveLockPeriodName
);
