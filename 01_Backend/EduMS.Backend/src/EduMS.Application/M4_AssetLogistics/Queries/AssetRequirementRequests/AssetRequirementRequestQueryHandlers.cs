using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetRequirementRequests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetRequirementRequests;

public class AssetRequirementRequestQueryHandlers : 
    IRequestHandler<GetAssetRequirementRequestByIdQuery, AssetRequirementRequestDto>,
    IRequestHandler<GetAllAssetRequirementRequestsQuery, IEnumerable<AssetRequirementRequestDto>>
{
    private readonly IGenericRepository<AssetRequirementRequest> _repository;
    private readonly IMapper _mapper;

    public AssetRequirementRequestQueryHandlers(IGenericRepository<AssetRequirementRequest> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetRequirementRequestDto> Handle(GetAssetRequirementRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetRequirementRequest not found.");
        return _mapper.Map<AssetRequirementRequestDto>(entity);
    }

    public async Task<IEnumerable<AssetRequirementRequestDto>> Handle(GetAllAssetRequirementRequestsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetRequirementRequestDto>>(entities);
    }
}