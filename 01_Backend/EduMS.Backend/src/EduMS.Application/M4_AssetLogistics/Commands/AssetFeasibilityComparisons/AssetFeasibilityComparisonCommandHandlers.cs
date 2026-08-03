using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityComparisons;

public class AssetFeasibilityComparisonCommandHandlers : 
    IRequestHandler<CreateAssetFeasibilityComparisonCommand, long>,
    IRequestHandler<UpdateAssetFeasibilityComparisonCommand, bool>,
    IRequestHandler<DeleteAssetFeasibilityComparisonCommand, bool>
{
    private readonly IGenericRepository<AssetFeasibilityComparison> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetFeasibilityComparisonCommandHandlers(IGenericRepository<AssetFeasibilityComparison> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetFeasibilityComparisonCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetFeasibilityComparison>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetFeasibilityComparisonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFeasibilityComparison not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetFeasibilityComparisonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFeasibilityComparison not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}