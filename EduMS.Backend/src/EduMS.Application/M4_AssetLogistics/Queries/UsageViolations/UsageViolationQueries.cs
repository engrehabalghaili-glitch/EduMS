using EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.UsageViolations;

public class GetUsageViolationByIdQuery : IRequest<UsageViolationDto>
{
    public long Id { get; set; }
}

public class GetAllUsageViolationsQuery : IRequest<IEnumerable<UsageViolationDto>>
{
}