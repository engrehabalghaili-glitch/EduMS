using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetWarrantyContracts;

public class AssetWarrantyContractQueryHandlers : 
    IRequestHandler<GetAssetWarrantyContractByIdQuery, AssetWarrantyContractDto>,
    IRequestHandler<GetAllAssetWarrantyContractsQuery, IEnumerable<AssetWarrantyContractDto>>
{
    private readonly IGenericRepository<AssetWarrantyContract> _repository;
    private readonly IMapper _mapper;

    public AssetWarrantyContractQueryHandlers(IGenericRepository<AssetWarrantyContract> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetWarrantyContractDto> Handle(GetAssetWarrantyContractByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetWarrantyContract not found.");
        return _mapper.Map<AssetWarrantyContractDto>(entity);
    }

    public async Task<IEnumerable<AssetWarrantyContractDto>> Handle(GetAllAssetWarrantyContractsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetWarrantyContractDto>>(entities);
    }
}