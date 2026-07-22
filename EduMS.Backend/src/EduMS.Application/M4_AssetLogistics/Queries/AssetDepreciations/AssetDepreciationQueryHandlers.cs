using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetDepreciations;

public class AssetDepreciationQueryHandlers : 
    IRequestHandler<GetAssetDepreciationByIdQuery, AssetDepreciationDto>,
    IRequestHandler<GetAllAssetDepreciationsQuery, IEnumerable<AssetDepreciationDto>>
{
    private readonly IGenericRepository<AssetDepreciation> _repository;
    private readonly IMapper _mapper;

    public AssetDepreciationQueryHandlers(IGenericRepository<AssetDepreciation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetDepreciationDto> Handle(GetAssetDepreciationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetDepreciation not found.");
        return _mapper.Map<AssetDepreciationDto>(entity);
    }

    public async Task<IEnumerable<AssetDepreciationDto>> Handle(GetAllAssetDepreciationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetDepreciationDto>>(entities);
    }
}