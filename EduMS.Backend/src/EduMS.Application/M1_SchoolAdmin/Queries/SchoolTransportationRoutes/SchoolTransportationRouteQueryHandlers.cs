using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolTransportationRoutes;

public class SchoolTransportationRouteQueryHandlers : 
    IRequestHandler<GetSchoolTransportationRouteByIdQuery, SchoolTransportationRouteDto>,
    IRequestHandler<GetAllSchoolTransportationRoutesQuery, IEnumerable<SchoolTransportationRouteDto>>
{
    private readonly IGenericRepository<SchoolTransportationRoute> _repository;
    private readonly IMapper _mapper;

    public SchoolTransportationRouteQueryHandlers(IGenericRepository<SchoolTransportationRoute> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolTransportationRouteDto> Handle(GetSchoolTransportationRouteByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolTransportationRoute not found.");
        return _mapper.Map<SchoolTransportationRouteDto>(entity);
    }

    public async Task<IEnumerable<SchoolTransportationRouteDto>> Handle(GetAllSchoolTransportationRoutesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolTransportationRouteDto>>(entities);
    }
}