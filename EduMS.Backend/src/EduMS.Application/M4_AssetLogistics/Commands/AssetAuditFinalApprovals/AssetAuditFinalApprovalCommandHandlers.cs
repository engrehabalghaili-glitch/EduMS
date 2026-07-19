using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAuditFinalApprovals;

public class AssetAuditFinalApprovalCommandHandlers : 
    IRequestHandler<CreateAssetAuditFinalApprovalCommand, long>,
    IRequestHandler<UpdateAssetAuditFinalApprovalCommand, bool>,
    IRequestHandler<DeleteAssetAuditFinalApprovalCommand, bool>
{
    private readonly IGenericRepository<AssetAuditFinalApproval> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetAuditFinalApprovalCommandHandlers(IGenericRepository<AssetAuditFinalApproval> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateAssetAuditFinalApprovalCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AssetAuditFinalApproval>(request.Dto);
        await _repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<bool> Handle(UpdateAssetAuditFinalApprovalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetAuditFinalApproval not found.");

        _mapper.Map(request.Dto, entity);
        await _repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> Handle(DeleteAssetAuditFinalApprovalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetAuditFinalApproval not found.");

        await _repository.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}