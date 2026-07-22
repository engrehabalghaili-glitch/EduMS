using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilityMaintenanceLogs;

public class SchoolFacilityMaintenanceLogQueryHandlers : 
    IRequestHandler<GetSchoolFacilityMaintenanceLogByIdQuery, SchoolFacilityMaintenanceLogDto>,
    IRequestHandler<GetAllSchoolFacilityMaintenanceLogsQuery, IEnumerable<SchoolFacilityMaintenanceLogDto>>
{
    private readonly IGenericRepository<SchoolFacilityMaintenanceLog> _repository;
    private readonly IMapper _mapper;

    public SchoolFacilityMaintenanceLogQueryHandlers(IGenericRepository<SchoolFacilityMaintenanceLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolFacilityMaintenanceLogDto> Handle(GetSchoolFacilityMaintenanceLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFacilityMaintenanceLog not found.");
        return _mapper.Map<SchoolFacilityMaintenanceLogDto>(entity);
    }

    public async Task<IEnumerable<SchoolFacilityMaintenanceLogDto>> Handle(GetAllSchoolFacilityMaintenanceLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolFacilityMaintenanceLogDto>>(entities);
    }
}