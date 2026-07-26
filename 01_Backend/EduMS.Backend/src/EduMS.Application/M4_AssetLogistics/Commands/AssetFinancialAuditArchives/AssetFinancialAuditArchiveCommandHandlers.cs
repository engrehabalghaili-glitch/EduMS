using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialAuditArchives;

public class AssetFinancialAuditArchiveCommandHandlers : 
    IRequestHandler<CreateAssetFinancialAuditArchiveCommand, long>,
    IRequestHandler<UpdateAssetFinancialAuditArchiveCommand, bool>,
    IRequestHandler<DeleteAssetFinancialAuditArchiveCommand, bool>
{
    private readonly IGenericRepository<AssetFinancialAuditArchive> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetFinancialAuditArchiveCommandHandlers(IGenericRepository<AssetFinancialAuditArchive> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetFinancialAuditArchiveCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetFinancialAuditArchive>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetFinancialAuditArchiveCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialAuditArchive not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetFinancialAuditArchiveCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialAuditArchive not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}