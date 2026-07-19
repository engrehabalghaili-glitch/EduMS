using EduMS.Application.M4_AssetLogistics.DTOs.EducationalConsumableTrackings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.EducationalConsumableTrackings;

public class GetEducationalConsumableTrackingByIdQuery : IRequest<EducationalConsumableTrackingDto>
{
    public long Id { get; set; }
}

public class GetAllEducationalConsumableTrackingsQuery : IRequest<IEnumerable<EducationalConsumableTrackingDto>>
{
}