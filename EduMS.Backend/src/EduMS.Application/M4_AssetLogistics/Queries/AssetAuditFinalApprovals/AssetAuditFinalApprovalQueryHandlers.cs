using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAuditFinalApprovals;

public class AssetAuditFinalApprovalQueryHandlers : 
    IRequestHandler<GetAssetAuditFinalApprovalByIdQuery, AssetAuditFinalApprovalDto>,
    IRequestHandler<GetAllAssetAuditFinalApprovalsQuery, IEnumerable<AssetAuditFinalApprovalDto>>
{
    private readonly IGenericRepository<AssetAuditFinalApproval> _repository;
    private readonly IMapper _mapper;

    public AssetAuditFinalApprovalQueryHandlers(IGenericRepository<AssetAuditFinalApproval> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetAuditFinalApprovalDto> Handle(GetAssetAuditFinalApprovalByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetAuditFinalApproval not found.");
        return _mapper.Map<AssetAuditFinalApprovalDto>(entity);
    }

    public async Task<IEnumerable<AssetAuditFinalApprovalDto>> Handle(GetAllAssetAuditFinalApprovalsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetAuditFinalApprovalDto>>(entities);
    }
}