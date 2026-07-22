using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PermissionTypes;

public class PermissionTypeQueryHandlers : 
    IRequestHandler<GetPermissionTypeByIdQuery, PermissionTypeDto>,
    IRequestHandler<GetAllPermissionTypesQuery, IEnumerable<PermissionTypeDto>>
{
    private readonly IGenericRepository<PermissionType> _repository;
    private readonly IMapper _mapper;

    public PermissionTypeQueryHandlers(IGenericRepository<PermissionType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PermissionTypeDto> Handle(GetPermissionTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PermissionType not found.");
        return _mapper.Map<PermissionTypeDto>(entity);
    }

    public async Task<IEnumerable<PermissionTypeDto>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PermissionTypeDto>>(entities);
    }
}