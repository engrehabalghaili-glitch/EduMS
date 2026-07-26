using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemRoles;

public class SystemRoleQueryHandlers : 
    IRequestHandler<GetSystemRoleByIdQuery, SystemRoleDto>,
    IRequestHandler<GetAllSystemRolesQuery, IEnumerable<SystemRoleDto>>
{
    private readonly IGenericRepository<SystemRole> _repository;
    private readonly IMapper _mapper;

    public SystemRoleQueryHandlers(IGenericRepository<SystemRole> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SystemRoleDto> Handle(GetSystemRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemRole not found.");
        return _mapper.Map<SystemRoleDto>(entity);
    }

    public async Task<IEnumerable<SystemRoleDto>> Handle(GetAllSystemRolesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SystemRoleDto>>(entities);
    }
}