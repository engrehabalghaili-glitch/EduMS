using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetTransferRequests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetTransferRequests;

public class AssetTransferRequestQueryHandlers : 
    IRequestHandler<GetAssetTransferRequestByIdQuery, AssetTransferRequestDto>,
    IRequestHandler<GetAllAssetTransferRequestsQuery, IEnumerable<AssetTransferRequestDto>>
{
    private readonly IGenericRepository<AssetTransferRequest> _repository;
    private readonly IMapper _mapper;

    public AssetTransferRequestQueryHandlers(IGenericRepository<AssetTransferRequest> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetTransferRequestDto> Handle(GetAssetTransferRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetTransferRequest not found.");
        return _mapper.Map<AssetTransferRequestDto>(entity);
    }

    public async Task<IEnumerable<AssetTransferRequestDto>> Handle(GetAllAssetTransferRequestsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetTransferRequestDto>>(entities);
    }
}