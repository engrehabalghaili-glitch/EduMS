using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAnnouncementLogs;

public class GetSchoolAnnouncementLogByIdQuery : IRequest<SchoolAnnouncementLogDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAnnouncementLogsQuery : IRequest<IEnumerable<SchoolAnnouncementLogDto>>
{
}