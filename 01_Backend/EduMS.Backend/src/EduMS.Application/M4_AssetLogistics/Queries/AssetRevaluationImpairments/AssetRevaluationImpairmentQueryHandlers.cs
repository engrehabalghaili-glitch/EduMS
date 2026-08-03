using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetRevaluationImpairments;

public class AssetRevaluationImpairmentQueryHandlers : 
    IRequestHandler<GetAssetRevaluationImpairmentByIdQuery, AssetRevaluationImpairmentDto>,
    IRequestHandler<GetAllAssetRevaluationImpairmentsQuery, IEnumerable<AssetRevaluationImpairmentDto>>
{
    private readonly IGenericRepository<AssetRevaluationImpairment> _repository;
    private readonly IMapper _mapper;

    public AssetRevaluationImpairmentQueryHandlers(IGenericRepository<AssetRevaluationImpairment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetRevaluationImpairmentDto> Handle(GetAssetRevaluationImpairmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetRevaluationImpairment not found.");
        return _mapper.Map<AssetRevaluationImpairmentDto>(entity);
    }

    public async Task<IEnumerable<AssetRevaluationImpairmentDto>> Handle(GetAllAssetRevaluationImpairmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetRevaluationImpairmentDto>>(entities);
    }
}