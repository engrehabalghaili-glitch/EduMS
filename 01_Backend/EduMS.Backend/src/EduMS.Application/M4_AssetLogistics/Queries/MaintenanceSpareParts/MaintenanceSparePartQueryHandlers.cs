using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceSpareParts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceSpareParts;

public class MaintenanceSparePartQueryHandlers : 
    IRequestHandler<GetMaintenanceSparePartByIdQuery, MaintenanceSparePartDto>,
    IRequestHandler<GetAllMaintenanceSparePartsQuery, IEnumerable<MaintenanceSparePartDto>>
{
    private readonly IGenericRepository<MaintenanceSparePart> _repository;
    private readonly IMapper _mapper;

    public MaintenanceSparePartQueryHandlers(IGenericRepository<MaintenanceSparePart> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MaintenanceSparePartDto> Handle(GetMaintenanceSparePartByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"MaintenanceSparePart not found.");
        return _mapper.Map<MaintenanceSparePartDto>(entity);
    }

    public async Task<IEnumerable<MaintenanceSparePartDto>> Handle(GetAllMaintenanceSparePartsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MaintenanceSparePartDto>>(entities);
    }
}