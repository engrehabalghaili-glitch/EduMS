using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyHostings;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyHostings;

public class EmergencyHostingQueryHandlers : 
    IRequestHandler<GetEmergencyHostingByIdQuery, EmergencyHostingDto>,
    IRequestHandler<GetAllEmergencyHostingsQuery, IEnumerable<EmergencyHostingDto>>
{
    private readonly IGenericRepository<EmergencyHosting> _repository;
    private readonly IMapper _mapper;

    public EmergencyHostingQueryHandlers(IGenericRepository<EmergencyHosting> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmergencyHostingDto> Handle(GetEmergencyHostingByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmergencyHosting not found.");
        return _mapper.Map<EmergencyHostingDto>(entity);
    }

    public async Task<IEnumerable<EmergencyHostingDto>> Handle(GetAllEmergencyHostingsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmergencyHostingDto>>(entities);
    }
}