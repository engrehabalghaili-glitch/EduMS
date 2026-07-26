using EduMS.Application.M4_AssetLogistics.DTOs.FieldInventoryLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.FieldInventoryLogs;

public class GetFieldInventoryLogByIdQuery : IRequest<FieldInventoryLogDto>
{
    public long Id { get; set; }
}

public class GetAllFieldInventoryLogsQuery : IRequest<IEnumerable<FieldInventoryLogDto>>
{
}