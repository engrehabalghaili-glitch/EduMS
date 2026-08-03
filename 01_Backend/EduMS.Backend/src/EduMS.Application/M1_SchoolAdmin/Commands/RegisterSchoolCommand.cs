using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Schools.Commands;

public record RegisterSchoolCommand(
    string SchoolNameAr,
    string SchoolNameEn,
    string SchoolCode,
    string Directorate,
    string Governorate
) : ICommand<long>;
