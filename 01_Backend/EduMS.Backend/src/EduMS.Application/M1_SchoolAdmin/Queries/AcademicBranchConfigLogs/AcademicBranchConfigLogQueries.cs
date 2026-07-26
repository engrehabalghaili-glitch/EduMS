using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicBranchConfigLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicBranchConfigLogs;

public class GetAcademicBranchConfigLogByIdQuery : IRequest<AcademicBranchConfigLogDto>
{
    public long Id { get; set; }
}

public class GetAllAcademicBranchConfigLogsQuery : IRequest<IEnumerable<AcademicBranchConfigLogDto>>
{
}