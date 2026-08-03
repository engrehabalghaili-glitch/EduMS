using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.EducationalStages;

public class EducationalStageQueryHandlers : 
    IRequestHandler<GetEducationalStageByIdQuery, EducationalStageDto>,
    IRequestHandler<GetAllEducationalStagesQuery, IEnumerable<EducationalStageDto>>
{
    private readonly IGenericRepository<EducationalStage> _repository;
    private readonly IMapper _mapper;

    public EducationalStageQueryHandlers(IGenericRepository<EducationalStage> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EducationalStageDto> Handle(GetEducationalStageByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalStage not found.");
        return _mapper.Map<EducationalStageDto>(entity);
    }

    public async Task<IEnumerable<EducationalStageDto>> Handle(GetAllEducationalStagesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EducationalStageDto>>(entities);
    }
}