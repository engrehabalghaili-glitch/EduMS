using EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.Warehouses;

public class GetWarehouseByIdQuery : IRequest<WarehouseDto>
{
    public long Id { get; set; }
}

public class GetAllWarehousesQuery : IRequest<IEnumerable<WarehouseDto>>
{
}