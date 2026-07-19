using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetTechnicalSpecifications;

public class AssetTechnicalSpecificationCommandHandlers : 
    IRequestHandler<CreateAssetTechnicalSpecificationCommand, long>,
    IRequestHandler<UpdateAssetTechnicalSpecificationCommand, bool>,
    IRequestHandler<DeleteAssetTechnicalSpecificationCommand, bool>
{
    private readonly IGenericRepository<AssetTechnicalSpecification> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetTechnicalSpecificationCommandHandlers(IGenericRepository<AssetTechnicalSpecification> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetTechnicalSpecificationCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetTechnicalSpecification>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetTechnicalSpecificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetTechnicalSpecification not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetTechnicalSpecificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetTechnicalSpecification not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}