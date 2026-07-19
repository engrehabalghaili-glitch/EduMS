using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionMatrixes;

public class BehaviorPermissionMatrixQueryHandlers : 
    IRequestHandler<GetBehaviorPermissionMatrixByIdQuery, BehaviorPermissionMatrixDto>,
    IRequestHandler<GetAllBehaviorPermissionMatrixesQuery, IEnumerable<BehaviorPermissionMatrixDto>>
{
    private readonly IGenericRepository<BehaviorPermissionMatrix> _repository;
    private readonly IMapper _mapper;

    public BehaviorPermissionMatrixQueryHandlers(IGenericRepository<BehaviorPermissionMatrix> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BehaviorPermissionMatrixDto> Handle(GetBehaviorPermissionMatrixByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehaviorPermissionMatrix not found.");
        return _mapper.Map<BehaviorPermissionMatrixDto>(entity);
    }

    public async Task<IEnumerable<BehaviorPermissionMatrixDto>> Handle(GetAllBehaviorPermissionMatrixesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BehaviorPermissionMatrixDto>>(entities);
    }
}