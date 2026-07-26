using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialAuditArchives;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialAuditArchives;

public class AssetFinancialAuditArchiveQueryHandlers : 
    IRequestHandler<GetAssetFinancialAuditArchiveByIdQuery, AssetFinancialAuditArchiveDto>,
    IRequestHandler<GetAllAssetFinancialAuditArchivesQuery, IEnumerable<AssetFinancialAuditArchiveDto>>
{
    private readonly IGenericRepository<AssetFinancialAuditArchive> _repository;
    private readonly IMapper _mapper;

    public AssetFinancialAuditArchiveQueryHandlers(IGenericRepository<AssetFinancialAuditArchive> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetFinancialAuditArchiveDto> Handle(GetAssetFinancialAuditArchiveByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFinancialAuditArchive not found.");
        return _mapper.Map<AssetFinancialAuditArchiveDto>(entity);
    }

    public async Task<IEnumerable<AssetFinancialAuditArchiveDto>> Handle(GetAllAssetFinancialAuditArchivesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetFinancialAuditArchiveDto>>(entities);
    }
}