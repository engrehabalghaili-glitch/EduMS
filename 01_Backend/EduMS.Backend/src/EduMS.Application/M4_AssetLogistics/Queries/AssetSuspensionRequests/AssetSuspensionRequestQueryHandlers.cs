using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetSuspensionRequests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetSuspensionRequests;

public class AssetSuspensionRequestQueryHandlers : 
    IRequestHandler<GetAssetSuspensionRequestByIdQuery, AssetSuspensionRequestDto>,
    IRequestHandler<GetAllAssetSuspensionRequestsQuery, IEnumerable<AssetSuspensionRequestDto>>
{
    private readonly IGenericRepository<AssetSuspensionRequest> _repository;
    private readonly IMapper _mapper;

    public AssetSuspensionRequestQueryHandlers(IGenericRepository<AssetSuspensionRequest> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetSuspensionRequestDto> Handle(GetAssetSuspensionRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetSuspensionRequest not found.");
        return _mapper.Map<AssetSuspensionRequestDto>(entity);
    }

    public async Task<IEnumerable<AssetSuspensionRequestDto>> Handle(GetAllAssetSuspensionRequestsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetSuspensionRequestDto>>(entities);
    }
}