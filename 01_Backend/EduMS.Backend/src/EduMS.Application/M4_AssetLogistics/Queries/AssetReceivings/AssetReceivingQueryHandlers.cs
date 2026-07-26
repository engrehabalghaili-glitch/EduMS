using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetReceivings;

public class AssetReceivingQueryHandlers : 
    IRequestHandler<GetAssetReceivingByIdQuery, AssetReceivingDto>,
    IRequestHandler<GetAllAssetReceivingsQuery, IEnumerable<AssetReceivingDto>>
{
    private readonly IGenericRepository<AssetReceiving> _repository;
    private readonly IMapper _mapper;

    public AssetReceivingQueryHandlers(IGenericRepository<AssetReceiving> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetReceivingDto> Handle(GetAssetReceivingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetReceiving not found.");
        return _mapper.Map<AssetReceivingDto>(entity);
    }

    public async Task<IEnumerable<AssetReceivingDto>> Handle(GetAllAssetReceivingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetReceivingDto>>(entities);
    }
}