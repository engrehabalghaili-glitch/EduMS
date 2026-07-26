using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.RoleMatrixes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.RoleMatrixes;

public class RoleMatrixQueryHandlers : 
    IRequestHandler<GetRoleMatrixByIdQuery, RoleMatrixDto>,
    IRequestHandler<GetAllRoleMatrixesQuery, IEnumerable<RoleMatrixDto>>
{
    private readonly IGenericRepository<RoleMatrix> _repository;
    private readonly IMapper _mapper;

    public RoleMatrixQueryHandlers(IGenericRepository<RoleMatrix> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RoleMatrixDto> Handle(GetRoleMatrixByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"RoleMatrix not found.");
        return _mapper.Map<RoleMatrixDto>(entity);
    }

    public async Task<IEnumerable<RoleMatrixDto>> Handle(GetAllRoleMatrixesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<RoleMatrixDto>>(entities);
    }
}