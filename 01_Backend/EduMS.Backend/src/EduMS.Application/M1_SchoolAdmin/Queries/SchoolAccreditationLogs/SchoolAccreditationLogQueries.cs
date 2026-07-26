using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAccreditationLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAccreditationLogs;

public class GetSchoolAccreditationLogByIdQuery : IRequest<SchoolAccreditationLogDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAccreditationLogsQuery : IRequest<IEnumerable<SchoolAccreditationLogDto>>
{
}