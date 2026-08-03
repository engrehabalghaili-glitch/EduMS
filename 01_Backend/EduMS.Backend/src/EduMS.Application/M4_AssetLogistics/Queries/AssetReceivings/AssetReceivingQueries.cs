using EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetReceivings;

public class GetAssetReceivingByIdQuery : IRequest<AssetReceivingDto>
{
    public long Id { get; set; }
}

public class GetAllAssetReceivingsQuery : IRequest<IEnumerable<AssetReceivingDto>>
{
}