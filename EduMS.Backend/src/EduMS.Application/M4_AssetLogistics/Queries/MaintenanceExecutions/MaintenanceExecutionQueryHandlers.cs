using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceExecutions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceExecutions;

public class MaintenanceExecutionQueryHandlers : 
    IRequestHandler<GetMaintenanceExecutionByIdQuery, MaintenanceExecutionDto>,
    IRequestHandler<GetAllMaintenanceExecutionsQuery, IEnumerable<MaintenanceExecutionDto>>
{
    private readonly IGenericRepository<MaintenanceExecution> _repository;
    private readonly IMapper _mapper;

    public MaintenanceExecutionQueryHandlers(IGenericRepository<MaintenanceExecution> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MaintenanceExecutionDto> Handle(GetMaintenanceExecutionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"MaintenanceExecution not found.");
        return _mapper.Map<MaintenanceExecutionDto>(entity);
    }

    public async Task<IEnumerable<MaintenanceExecutionDto>> Handle(GetAllMaintenanceExecutionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MaintenanceExecutionDto>>(entities);
    }
}