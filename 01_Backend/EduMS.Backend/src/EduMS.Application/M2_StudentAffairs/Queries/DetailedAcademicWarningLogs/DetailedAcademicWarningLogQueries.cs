using EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.DetailedAcademicWarningLogs;

public class GetDetailedAcademicWarningLogByIdQuery : IRequest<DetailedAcademicWarningLogDto>
{
    public long Id { get; set; }
}

public class GetAllDetailedAcademicWarningLogsQuery : IRequest<IEnumerable<DetailedAcademicWarningLogDto>>
{
}