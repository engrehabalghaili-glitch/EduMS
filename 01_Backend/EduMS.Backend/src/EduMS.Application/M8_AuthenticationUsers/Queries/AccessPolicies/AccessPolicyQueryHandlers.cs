using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.AccessPolicies;

public class AccessPolicyQueryHandlers : 
    IRequestHandler<GetAccessPolicyByIdQuery, AccessPolicyDto>,
    IRequestHandler<GetAllAccessPoliciesQuery, IEnumerable<AccessPolicyDto>>
{
    private readonly IGenericRepository<AccessPolicy> _repository;
    private readonly IMapper _mapper;

    public AccessPolicyQueryHandlers(IGenericRepository<AccessPolicy> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AccessPolicyDto> Handle(GetAccessPolicyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AccessPolicy not found.");
        return _mapper.Map<AccessPolicyDto>(entity);
    }

    public async Task<IEnumerable<AccessPolicyDto>> Handle(GetAllAccessPoliciesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AccessPolicyDto>>(entities);
    }
}