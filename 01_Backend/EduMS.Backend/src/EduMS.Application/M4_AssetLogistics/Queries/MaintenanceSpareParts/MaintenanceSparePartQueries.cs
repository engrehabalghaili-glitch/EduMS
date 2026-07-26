using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceSpareParts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceSpareParts;

public class GetMaintenanceSparePartByIdQuery : IRequest<MaintenanceSparePartDto>
{
    public long Id { get; set; }
}

public class GetAllMaintenanceSparePartsQuery : IRequest<IEnumerable<MaintenanceSparePartDto>>
{
}