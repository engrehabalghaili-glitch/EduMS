using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.TransportationServices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.TransportationServices;

public class TransportationServiceQueryHandlers : 
    IRequestHandler<GetTransportationServiceByIdQuery, TransportationServiceDto>,
    IRequestHandler<GetAllTransportationServicesQuery, IEnumerable<TransportationServiceDto>>
{
    private readonly IGenericRepository<TransportationService> _repository;
    private readonly IMapper _mapper;

    public TransportationServiceQueryHandlers(IGenericRepository<TransportationService> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransportationServiceDto> Handle(GetTransportationServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"TransportationService not found.");
        return _mapper.Map<TransportationServiceDto>(entity);
    }

    public async Task<IEnumerable<TransportationServiceDto>> Handle(GetAllTransportationServicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TransportationServiceDto>>(entities);
    }
}