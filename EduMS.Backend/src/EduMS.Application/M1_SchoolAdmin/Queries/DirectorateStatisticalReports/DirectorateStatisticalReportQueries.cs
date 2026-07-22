using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateStatisticalReports;

public class GetDirectorateStatisticalReportByIdQuery : IRequest<DirectorateStatisticalReportDto>
{
    public long Id { get; set; }
}

public class GetAllDirectorateStatisticalReportsQuery : IRequest<IEnumerable<DirectorateStatisticalReportDto>>
{
}