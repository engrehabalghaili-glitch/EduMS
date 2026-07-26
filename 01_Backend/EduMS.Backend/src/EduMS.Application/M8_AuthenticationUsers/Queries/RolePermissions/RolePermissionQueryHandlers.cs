using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.RolePermissions;

public class RolePermissionQueryHandlers : 
    IRequestHandler<GetRolePermissionByIdQuery, RolePermissionDto>,
    IRequestHandler<GetAllRolePermissionsQuery, IEnumerable<RolePermissionDto>>
{
    private readonly IGenericRepository<RolePermission> _repository;
    private readonly IMapper _mapper;

    public RolePermissionQueryHandlers(IGenericRepository<RolePermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RolePermissionDto> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"RolePermission not found.");
        return _mapper.Map<RolePermissionDto>(entity);
    }

    public async Task<IEnumerable<RolePermissionDto>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<RolePermissionDto>>(entities);
    }
}