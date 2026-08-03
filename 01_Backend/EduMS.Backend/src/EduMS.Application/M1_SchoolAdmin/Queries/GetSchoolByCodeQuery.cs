using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Schools.Queries;

public record GetSchoolByCodeQuery(string SchoolCode) : IQuery<SchoolDetailsDto?>;
