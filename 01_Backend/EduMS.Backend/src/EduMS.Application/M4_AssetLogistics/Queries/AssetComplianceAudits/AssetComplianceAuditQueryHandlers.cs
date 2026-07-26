using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetComplianceAudits;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetComplianceAudits;

public class AssetComplianceAuditQueryHandlers : 
    IRequestHandler<GetAssetComplianceAuditByIdQuery, AssetComplianceAuditDto>,
    IRequestHandler<GetAllAssetComplianceAuditsQuery, IEnumerable<AssetComplianceAuditDto>>
{
    private readonly IGenericRepository<AssetComplianceAudit> _repository;
    private readonly IMapper _mapper;

    public AssetComplianceAuditQueryHandlers(IGenericRepository<AssetComplianceAudit> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetComplianceAuditDto> Handle(GetAssetComplianceAuditByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetComplianceAudit not found.");
        return _mapper.Map<AssetComplianceAuditDto>(entity);
    }

    public async Task<IEnumerable<AssetComplianceAuditDto>> Handle(GetAllAssetComplianceAuditsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetComplianceAuditDto>>(entities);
    }
}