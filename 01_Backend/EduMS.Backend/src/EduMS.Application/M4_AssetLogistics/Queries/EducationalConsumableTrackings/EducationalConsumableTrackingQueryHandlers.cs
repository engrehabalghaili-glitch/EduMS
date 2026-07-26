using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.EducationalConsumableTrackings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.EducationalConsumableTrackings;

public class EducationalConsumableTrackingQueryHandlers : 
    IRequestHandler<GetEducationalConsumableTrackingByIdQuery, EducationalConsumableTrackingDto>,
    IRequestHandler<GetAllEducationalConsumableTrackingsQuery, IEnumerable<EducationalConsumableTrackingDto>>
{
    private readonly IGenericRepository<EducationalConsumableTracking> _repository;
    private readonly IMapper _mapper;

    public EducationalConsumableTrackingQueryHandlers(IGenericRepository<EducationalConsumableTracking> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EducationalConsumableTrackingDto> Handle(GetEducationalConsumableTrackingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EducationalConsumableTracking not found.");
        return _mapper.Map<EducationalConsumableTrackingDto>(entity);
    }

    public async Task<IEnumerable<EducationalConsumableTrackingDto>> Handle(GetAllEducationalConsumableTrackingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EducationalConsumableTrackingDto>>(entities);
    }
}