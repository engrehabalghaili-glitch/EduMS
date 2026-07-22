using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.ExternalParticipations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.ExternalParticipations;

public class ExternalParticipationQueryHandlers : 
    IRequestHandler<GetExternalParticipationByIdQuery, ExternalParticipationDto>,
    IRequestHandler<GetAllExternalParticipationsQuery, IEnumerable<ExternalParticipationDto>>
{
    private readonly IGenericRepository<ExternalParticipation> _repository;
    private readonly IMapper _mapper;

    public ExternalParticipationQueryHandlers(IGenericRepository<ExternalParticipation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ExternalParticipationDto> Handle(GetExternalParticipationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExternalParticipation not found.");
        return _mapper.Map<ExternalParticipationDto>(entity);
    }

    public async Task<IEnumerable<ExternalParticipationDto>> Handle(GetAllExternalParticipationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ExternalParticipationDto>>(entities);
    }
}