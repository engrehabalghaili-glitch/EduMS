using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLoanTrackingAlerts;

public class AssetLoanTrackingAlertQueryHandlers : 
    IRequestHandler<GetAssetLoanTrackingAlertByIdQuery, AssetLoanTrackingAlertDto>,
    IRequestHandler<GetAllAssetLoanTrackingAlertsQuery, IEnumerable<AssetLoanTrackingAlertDto>>
{
    private readonly IGenericRepository<AssetLoanTrackingAlert> _repository;
    private readonly IMapper _mapper;

    public AssetLoanTrackingAlertQueryHandlers(IGenericRepository<AssetLoanTrackingAlert> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetLoanTrackingAlertDto> Handle(GetAssetLoanTrackingAlertByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetLoanTrackingAlert not found.");
        return _mapper.Map<AssetLoanTrackingAlertDto>(entity);
    }

    public async Task<IEnumerable<AssetLoanTrackingAlertDto>> Handle(GetAllAssetLoanTrackingAlertsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetLoanTrackingAlertDto>>(entities);
    }
}