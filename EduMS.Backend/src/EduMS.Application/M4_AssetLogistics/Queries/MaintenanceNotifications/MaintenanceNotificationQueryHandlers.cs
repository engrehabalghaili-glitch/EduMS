using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceNotifications;

public class MaintenanceNotificationQueryHandlers : 
    IRequestHandler<GetMaintenanceNotificationByIdQuery, MaintenanceNotificationDto>,
    IRequestHandler<GetAllMaintenanceNotificationsQuery, IEnumerable<MaintenanceNotificationDto>>
{
    private readonly IGenericRepository<MaintenanceNotification> _repository;
    private readonly IMapper _mapper;

    public MaintenanceNotificationQueryHandlers(IGenericRepository<MaintenanceNotification> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MaintenanceNotificationDto> Handle(GetMaintenanceNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"MaintenanceNotification not found.");
        return _mapper.Map<MaintenanceNotificationDto>(entity);
    }

    public async Task<IEnumerable<MaintenanceNotificationDto>> Handle(GetAllMaintenanceNotificationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MaintenanceNotificationDto>>(entities);
    }
}