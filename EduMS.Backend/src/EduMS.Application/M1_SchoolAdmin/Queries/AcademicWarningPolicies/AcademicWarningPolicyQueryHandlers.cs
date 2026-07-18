using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicWarningPolicies;

public class AcademicWarningPolicyQueryHandlers : 
    IRequestHandler<GetAcademicWarningPolicyByIdQuery, AcademicWarningPolicyDto>,
    IRequestHandler<GetAllAcademicWarningPoliciesQuery, IEnumerable<AcademicWarningPolicyDto>>
{
    private readonly IGenericRepository<AcademicWarningPolicy> _repository;
    private readonly IMapper _mapper;

    public AcademicWarningPolicyQueryHandlers(IGenericRepository<AcademicWarningPolicy> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AcademicWarningPolicyDto> Handle(GetAcademicWarningPolicyByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AcademicWarningPolicy not found.");
        return _mapper.Map<AcademicWarningPolicyDto>(entity);
    }

    public async Task<IEnumerable<AcademicWarningPolicyDto>> Handle(GetAllAcademicWarningPoliciesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AcademicWarningPolicyDto>>(entities);
    }
}