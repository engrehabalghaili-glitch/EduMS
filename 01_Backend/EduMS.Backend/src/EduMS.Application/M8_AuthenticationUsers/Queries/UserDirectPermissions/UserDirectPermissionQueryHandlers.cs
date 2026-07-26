using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserDirectPermissions;

public class UserDirectPermissionQueryHandlers : 
    IRequestHandler<GetUserDirectPermissionByIdQuery, UserDirectPermissionDto>,
    IRequestHandler<GetAllUserDirectPermissionsQuery, IEnumerable<UserDirectPermissionDto>>
{
    private readonly IGenericRepository<UserDirectPermission> _repository;
    private readonly IMapper _mapper;

    public UserDirectPermissionQueryHandlers(IGenericRepository<UserDirectPermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDirectPermissionDto> Handle(GetUserDirectPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"UserDirectPermission not found.");
        return _mapper.Map<UserDirectPermissionDto>(entity);
    }

    public async Task<IEnumerable<UserDirectPermissionDto>> Handle(GetAllUserDirectPermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserDirectPermissionDto>>(entities);
    }
}