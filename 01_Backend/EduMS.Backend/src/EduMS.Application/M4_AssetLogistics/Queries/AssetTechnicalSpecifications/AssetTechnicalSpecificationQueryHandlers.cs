using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetTechnicalSpecifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetTechnicalSpecifications;

public class AssetTechnicalSpecificationQueryHandlers : 
    IRequestHandler<GetAssetTechnicalSpecificationByIdQuery, AssetTechnicalSpecificationDto>,
    IRequestHandler<GetAllAssetTechnicalSpecificationsQuery, IEnumerable<AssetTechnicalSpecificationDto>>
{
    private readonly IGenericRepository<AssetTechnicalSpecification> _repository;
    private readonly IMapper _mapper;

    public AssetTechnicalSpecificationQueryHandlers(IGenericRepository<AssetTechnicalSpecification> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetTechnicalSpecificationDto> Handle(GetAssetTechnicalSpecificationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetTechnicalSpecification not found.");
        return _mapper.Map<AssetTechnicalSpecificationDto>(entity);
    }

    public async Task<IEnumerable<AssetTechnicalSpecificationDto>> Handle(GetAllAssetTechnicalSpecificationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetTechnicalSpecificationDto>>(entities);
    }
}