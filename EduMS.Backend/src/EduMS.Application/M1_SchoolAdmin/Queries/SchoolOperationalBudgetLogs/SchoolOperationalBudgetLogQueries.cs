using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolOperationalBudgetLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolOperationalBudgetLogs;

public class GetSchoolOperationalBudgetLogByIdQuery : IRequest<SchoolOperationalBudgetLogDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolOperationalBudgetLogsQuery : IRequest<IEnumerable<SchoolOperationalBudgetLogDto>>
{
}