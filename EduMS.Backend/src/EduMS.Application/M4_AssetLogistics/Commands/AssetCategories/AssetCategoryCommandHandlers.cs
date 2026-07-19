using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetCategories;

public class AssetCategoryCommandHandlers : 
    IRequestHandler<CreateAssetCategoryCommand, long>,
    IRequestHandler<UpdateAssetCategoryCommand, bool>,
    IRequestHandler<DeleteAssetCategoryCommand, bool>
{
    private readonly IGenericRepository<AssetCategory> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetCategoryCommandHandlers(IGenericRepository<AssetCategory> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetCategory>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetCategory not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetCategory not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}