using EduMS.Application.M4_AssetLogistics.DTOs.FieldInventoryLogs;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.FieldInventoryLogs;

public class CreateFieldInventoryLogCommand : IRequest<long>
{
    public CreateFieldInventoryLogDto Dto { get; set; } = new();
}

public class UpdateFieldInventoryLogCommand : IRequest<bool>
{
    public UpdateFieldInventoryLogDto Dto { get; set; } = new();
}

public class DeleteFieldInventoryLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}