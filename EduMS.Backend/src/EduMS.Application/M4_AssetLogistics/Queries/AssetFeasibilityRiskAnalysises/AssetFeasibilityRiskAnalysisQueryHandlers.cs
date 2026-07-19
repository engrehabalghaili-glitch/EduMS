using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityRiskAnalysises;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityRiskAnalysises;

public class AssetFeasibilityRiskAnalysisQueryHandlers : 
    IRequestHandler<GetAssetFeasibilityRiskAnalysisByIdQuery, AssetFeasibilityRiskAnalysisDto>,
    IRequestHandler<GetAllAssetFeasibilityRiskAnalysisesQuery, IEnumerable<AssetFeasibilityRiskAnalysisDto>>
{
    private readonly IGenericRepository<AssetFeasibilityRiskAnalysis> _repository;
    private readonly IMapper _mapper;

    public AssetFeasibilityRiskAnalysisQueryHandlers(IGenericRepository<AssetFeasibilityRiskAnalysis> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetFeasibilityRiskAnalysisDto> Handle(GetAssetFeasibilityRiskAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFeasibilityRiskAnalysis not found.");
        return _mapper.Map<AssetFeasibilityRiskAnalysisDto>(entity);
    }

    public async Task<IEnumerable<AssetFeasibilityRiskAnalysisDto>> Handle(GetAllAssetFeasibilityRiskAnalysisesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetFeasibilityRiskAnalysisDto>>(entities);
    }
}