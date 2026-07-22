using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PrivilegeRules;

public class PrivilegeRuleQueryHandlers : 
    IRequestHandler<GetPrivilegeRuleByIdQuery, PrivilegeRuleDto>,
    IRequestHandler<GetAllPrivilegeRulesQuery, IEnumerable<PrivilegeRuleDto>>
{
    private readonly IGenericRepository<PrivilegeRule> _repository;
    private readonly IMapper _mapper;

    public PrivilegeRuleQueryHandlers(IGenericRepository<PrivilegeRule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PrivilegeRuleDto> Handle(GetPrivilegeRuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PrivilegeRule not found.");
        return _mapper.Map<PrivilegeRuleDto>(entity);
    }

    public async Task<IEnumerable<PrivilegeRuleDto>> Handle(GetAllPrivilegeRulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PrivilegeRuleDto>>(entities);
    }
}