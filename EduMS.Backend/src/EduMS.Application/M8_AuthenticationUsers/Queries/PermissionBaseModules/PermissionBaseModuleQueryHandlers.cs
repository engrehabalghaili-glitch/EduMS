using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PermissionBaseModules;

public class PermissionBaseModuleQueryHandlers : 
    IRequestHandler<GetPermissionBaseModuleByIdQuery, PermissionBaseModuleDto>,
    IRequestHandler<GetAllPermissionBaseModulesQuery, IEnumerable<PermissionBaseModuleDto>>
{
    private readonly IGenericRepository<PermissionBaseModule> _repository;
    private readonly IMapper _mapper;

    public PermissionBaseModuleQueryHandlers(IGenericRepository<PermissionBaseModule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PermissionBaseModuleDto> Handle(GetPermissionBaseModuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PermissionBaseModule not found.");
        return _mapper.Map<PermissionBaseModuleDto>(entity);
    }

    public async Task<IEnumerable<PermissionBaseModuleDto>> Handle(GetAllPermissionBaseModulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PermissionBaseModuleDto>>(entities);
    }
}