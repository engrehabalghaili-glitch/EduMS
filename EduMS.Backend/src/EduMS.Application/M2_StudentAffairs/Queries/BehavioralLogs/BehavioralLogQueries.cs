using EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.BehavioralLogs;

public class GetBehavioralLogByIdQuery : IRequest<BehavioralLogDto>
{
    public long Id { get; set; }
}

public class GetAllBehavioralLogsQuery : IRequest<IEnumerable<BehavioralLogDto>>
{
}