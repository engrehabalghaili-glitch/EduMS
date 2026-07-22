using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemAuditLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemAuditLogs;

public class SystemAuditLogQueryHandlers : 
    IRequestHandler<GetSystemAuditLogByIdQuery, SystemAuditLogDto>,
    IRequestHandler<GetAllSystemAuditLogsQuery, IEnumerable<SystemAuditLogDto>>
{
    private readonly IGenericRepository<SystemAuditLog> _repository;
    private readonly IMapper _mapper;

    public SystemAuditLogQueryHandlers(IGenericRepository<SystemAuditLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SystemAuditLogDto> Handle(GetSystemAuditLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemAuditLog not found.");
        return _mapper.Map<SystemAuditLogDto>(entity);
    }

    public async Task<IEnumerable<SystemAuditLogDto>> Handle(GetAllSystemAuditLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SystemAuditLogDto>>(entities);
    }
}