using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyClosures;

public class EmergencyClosureQueryHandlers : 
    IRequestHandler<GetEmergencyClosureByIdQuery, EmergencyClosureDto>,
    IRequestHandler<GetAllEmergencyClosuresQuery, IEnumerable<EmergencyClosureDto>>
{
    private readonly IGenericRepository<EmergencyClosure> _repository;
    private readonly IMapper _mapper;

    public EmergencyClosureQueryHandlers(IGenericRepository<EmergencyClosure> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmergencyClosureDto> Handle(GetEmergencyClosureByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmergencyClosure not found.");
        return _mapper.Map<EmergencyClosureDto>(entity);
    }

    public async Task<IEnumerable<EmergencyClosureDto>> Handle(GetAllEmergencyClosuresQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmergencyClosureDto>>(entities);
    }
}