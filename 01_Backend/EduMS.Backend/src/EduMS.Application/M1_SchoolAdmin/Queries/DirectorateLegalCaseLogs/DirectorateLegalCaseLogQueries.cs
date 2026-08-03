using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateLegalCaseLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateLegalCaseLogs;

public class GetDirectorateLegalCaseLogByIdQuery : IRequest<DirectorateLegalCaseLogDto>
{
    public long Id { get; set; }
}

public class GetAllDirectorateLegalCaseLogsQuery : IRequest<IEnumerable<DirectorateLegalCaseLogDto>>
{
}