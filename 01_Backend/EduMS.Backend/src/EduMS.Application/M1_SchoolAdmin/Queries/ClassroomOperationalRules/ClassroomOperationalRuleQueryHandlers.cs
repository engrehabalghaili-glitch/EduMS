using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassroomOperationalRules;

public class ClassroomOperationalRuleQueryHandlers : 
    IRequestHandler<GetClassroomOperationalRuleByIdQuery, ClassroomOperationalRuleDto>,
    IRequestHandler<GetAllClassroomOperationalRulesQuery, IEnumerable<ClassroomOperationalRuleDto>>
{
    private readonly IGenericRepository<ClassroomOperationalRule> _repository;
    private readonly IMapper _mapper;

    public ClassroomOperationalRuleQueryHandlers(IGenericRepository<ClassroomOperationalRule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClassroomOperationalRuleDto> Handle(GetClassroomOperationalRuleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomOperationalRule not found.");
        return _mapper.Map<ClassroomOperationalRuleDto>(entity);
    }

    public async Task<IEnumerable<ClassroomOperationalRuleDto>> Handle(GetAllClassroomOperationalRulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ClassroomOperationalRuleDto>>(entities);
    }
}