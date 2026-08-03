using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissions;

public class BehaviorPermissionQueryHandlers : 
    IRequestHandler<GetBehaviorPermissionByIdQuery, BehaviorPermissionDto>,
    IRequestHandler<GetAllBehaviorPermissionsQuery, IEnumerable<BehaviorPermissionDto>>
{
    private readonly IGenericRepository<BehaviorPermission> _repository;
    private readonly IMapper _mapper;

    public BehaviorPermissionQueryHandlers(IGenericRepository<BehaviorPermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BehaviorPermissionDto> Handle(GetBehaviorPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehaviorPermission not found.");
        return _mapper.Map<BehaviorPermissionDto>(entity);
    }

    public async Task<IEnumerable<BehaviorPermissionDto>> Handle(GetAllBehaviorPermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BehaviorPermissionDto>>(entities);
    }
}