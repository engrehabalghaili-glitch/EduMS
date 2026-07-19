using EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.Warehouses;

public class CreateWarehouseCommand : IRequest<long>
{
    public CreateWarehouseDto Dto { get; set; } = new();
}

public class UpdateWarehouseCommand : IRequest<bool>
{
    public UpdateWarehouseDto Dto { get; set; } = new();
}

public class DeleteWarehouseCommand : IRequest<bool>
{
    public long Id { get; set; }
}