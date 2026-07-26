using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.OfficePermissions;

public class OfficePermissionQueryHandlers : 
    IRequestHandler<GetOfficePermissionByIdQuery, OfficePermissionDto>,
    IRequestHandler<GetAllOfficePermissionsQuery, IEnumerable<OfficePermissionDto>>
{
    private readonly IGenericRepository<OfficePermission> _repository;
    private readonly IMapper _mapper;

    public OfficePermissionQueryHandlers(IGenericRepository<OfficePermission> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OfficePermissionDto> Handle(GetOfficePermissionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"OfficePermission not found.");
        return _mapper.Map<OfficePermissionDto>(entity);
    }

    public async Task<IEnumerable<OfficePermissionDto>> Handle(GetAllOfficePermissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<OfficePermissionDto>>(entities);
    }
}