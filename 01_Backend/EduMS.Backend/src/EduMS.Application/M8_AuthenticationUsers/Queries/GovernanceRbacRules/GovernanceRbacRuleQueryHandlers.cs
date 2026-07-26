using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.GovernanceRbacRules;

public class GovernanceRbacRuleQueryHandlers : 
    IRequestHandler<GetGovernanceRbacRuleByIdQuery, GovernanceRbacRuleDto>,
    IRequestHandler<GetAllGovernanceRbacRulesQuery, IEnumerable<GovernanceRbacRuleDto>>
{
    private readonly IGenericRepository<GovernanceRbacRule> _repository;
    private readonly IMapper _mapper;

    public GovernanceRbacRuleQueryHandlers(IGenericRepository<GovernanceRbacRule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GovernanceRbacRuleDto> Handle(GetGovernanceRbacRuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"GovernanceRbacRule not found.");
        return _mapper.Map<GovernanceRbacRuleDto>(entity);
    }

    public async Task<IEnumerable<GovernanceRbacRuleDto>> Handle(GetAllGovernanceRbacRulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<GovernanceRbacRuleDto>>(entities);
    }
}