using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemPermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemPermissions;

public class SystemPermissionQueryHandlers : 
    IRequestHandler<GetSystemPermissionByIdQuery, SystemPermissionDto>,
    IRequestHandler<GetAllSystemPermissionsQuery, IEnumerable<SystemPermissionDto>>
{
    private readonly IGenericRepository<SystemPermission> _repository;
    private readonly IMapper _mapper;

    public SystemPermissionQueryHandlers(IGenericRepository<SystemPermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SystemPermissionDto> Handle(GetSystemPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemPermission not found.");
        return _mapper.Map<SystemPermissionDto>(entity);
    }

    public async Task<IEnumerable<SystemPermissionDto>> Handle(GetAllSystemPermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SystemPermissionDto>>(entities);
    }
}