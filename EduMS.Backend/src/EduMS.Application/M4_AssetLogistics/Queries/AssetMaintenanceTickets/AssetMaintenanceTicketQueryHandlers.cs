using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetMaintenanceTickets;

public class AssetMaintenanceTicketQueryHandlers : 
    IRequestHandler<GetAssetMaintenanceTicketByIdQuery, AssetMaintenanceTicketDto>,
    IRequestHandler<GetAllAssetMaintenanceTicketsQuery, IEnumerable<AssetMaintenanceTicketDto>>
{
    private readonly IGenericRepository<AssetMaintenanceTicket> _repository;
    private readonly IMapper _mapper;

    public AssetMaintenanceTicketQueryHandlers(IGenericRepository<AssetMaintenanceTicket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetMaintenanceTicketDto> Handle(GetAssetMaintenanceTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetMaintenanceTicket not found.");
        return _mapper.Map<AssetMaintenanceTicketDto>(entity);
    }

    public async Task<IEnumerable<AssetMaintenanceTicketDto>> Handle(GetAllAssetMaintenanceTicketsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetMaintenanceTicketDto>>(entities);
    }
}