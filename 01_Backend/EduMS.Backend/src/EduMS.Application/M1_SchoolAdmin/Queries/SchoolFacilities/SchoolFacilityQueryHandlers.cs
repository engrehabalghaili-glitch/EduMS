using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolFacilities;

public class SchoolFacilityQueryHandlers : 
    IRequestHandler<GetSchoolFacilityByIdQuery, SchoolFacilityDto>,
    IRequestHandler<GetAllSchoolFacilitiesQuery, IEnumerable<SchoolFacilityDto>>
{
    private readonly IGenericRepository<SchoolFacility> _repository;
    private readonly IMapper _mapper;

    public SchoolFacilityQueryHandlers(IGenericRepository<SchoolFacility> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SchoolFacilityDto> Handle(GetSchoolFacilityByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFacility not found.");
        return _mapper.Map<SchoolFacilityDto>(entity);
    }

    public async Task<IEnumerable<SchoolFacilityDto>> Handle(GetAllSchoolFacilitiesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SchoolFacilityDto>>(entities);
    }
}