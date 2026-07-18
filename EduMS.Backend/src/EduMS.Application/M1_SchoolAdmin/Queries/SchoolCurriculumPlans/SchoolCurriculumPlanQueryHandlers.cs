using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolCurriculumPlans;

public class SchoolCurriculumPlanQueryHandlers : 
    IRequestHandler<GetSchoolCurriculumPlanByIdQuery, SchoolCurriculumPlanDto>,
    IRequestHandler<GetAllSchoolCurriculumPlansQuery, IEnumerable<SchoolCurriculumPlanDto>>
{
    private readonly IGenericRepository<SchoolCurriculumPlan> _repository;
    private readonly IMapper _mapper;

    public SchoolCurriculumPlanQueryHandlers(IGenericRepository<SchoolCurriculumPlan> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolCurriculumPlanDto> Handle(GetSchoolCurriculumPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolCurriculumPlan not found.");
        return _mapper.Map<SchoolCurriculumPlanDto>(entity);
    }

    public async Task<IEnumerable<SchoolCurriculumPlanDto>> Handle(GetAllSchoolCurriculumPlansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolCurriculumPlanDto>>(entities);
    }
}