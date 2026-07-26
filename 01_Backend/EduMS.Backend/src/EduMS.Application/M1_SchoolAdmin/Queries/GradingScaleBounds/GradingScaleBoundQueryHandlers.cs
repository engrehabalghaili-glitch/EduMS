using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.GradingScaleBounds;

public class GradingScaleBoundQueryHandlers : 
    IRequestHandler<GetGradingScaleBoundByIdQuery, GradingScaleBoundDto>,
    IRequestHandler<GetAllGradingScaleBoundsQuery, IEnumerable<GradingScaleBoundDto>>
{
    private readonly IGenericRepository<GradingScaleBound> _repository;
    private readonly IMapper _mapper;

    public GradingScaleBoundQueryHandlers(IGenericRepository<GradingScaleBound> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GradingScaleBoundDto> Handle(GetGradingScaleBoundByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"GradingScaleBound not found.");
        return _mapper.Map<GradingScaleBoundDto>(entity);
    }

    public async Task<IEnumerable<GradingScaleBoundDto>> Handle(GetAllGradingScaleBoundsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<GradingScaleBoundDto>>(entities);
    }
}