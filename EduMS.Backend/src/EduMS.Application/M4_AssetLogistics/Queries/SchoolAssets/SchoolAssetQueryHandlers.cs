using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.SchoolAssets;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.SchoolAssets;

public class SchoolAssetQueryHandlers : 
    IRequestHandler<GetSchoolAssetByIdQuery, SchoolAssetDto>,
    IRequestHandler<GetAllSchoolAssetsQuery, IEnumerable<SchoolAssetDto>>
{
    private readonly IGenericRepository<SchoolAsset> _repository;
    private readonly IMapper _mapper;

    public SchoolAssetQueryHandlers(IGenericRepository<SchoolAsset> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolAssetDto> Handle(GetSchoolAssetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolAsset not found.");
        return _mapper.Map<SchoolAssetDto>(entity);
    }

    public async Task<IEnumerable<SchoolAssetDto>> Handle(GetAllSchoolAssetsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolAssetDto>>(entities);
    }
}