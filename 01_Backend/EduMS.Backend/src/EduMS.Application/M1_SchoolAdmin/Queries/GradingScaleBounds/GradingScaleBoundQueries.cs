using EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.GradingScaleBounds;

public class GetGradingScaleBoundByIdQuery : IRequest<GradingScaleBoundDto>
{
    public long Id { get; set; }
}

public class GetAllGradingScaleBoundsQuery : IRequest<IEnumerable<GradingScaleBoundDto>>
{
}