using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.GradeCapacities;

public class GradeCapacityQueryHandlers : 
    IRequestHandler<GetGradeCapacityByIdQuery, GradeCapacityDto>,
    IRequestHandler<GetAllGradeCapacitiesQuery, IEnumerable<GradeCapacityDto>>
{
    private readonly IGenericRepository<GradeCapacity> _repository;
    private readonly IMapper _mapper;

    public GradeCapacityQueryHandlers(IGenericRepository<GradeCapacity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GradeCapacityDto> Handle(GetGradeCapacityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"GradeCapacity not found.");
        return _mapper.Map<GradeCapacityDto>(entity);
    }

    public async Task<IEnumerable<GradeCapacityDto>> Handle(GetAllGradeCapacitiesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<GradeCapacityDto>>(entities);
    }
}