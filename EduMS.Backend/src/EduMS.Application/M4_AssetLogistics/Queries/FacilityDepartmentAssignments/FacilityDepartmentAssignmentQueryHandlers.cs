using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.FacilityDepartmentAssignments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.FacilityDepartmentAssignments;

public class FacilityDepartmentAssignmentQueryHandlers : 
    IRequestHandler<GetFacilityDepartmentAssignmentByIdQuery, FacilityDepartmentAssignmentDto>,
    IRequestHandler<GetAllFacilityDepartmentAssignmentsQuery, IEnumerable<FacilityDepartmentAssignmentDto>>
{
    private readonly IGenericRepository<FacilityDepartmentAssignment> _repository;
    private readonly IMapper _mapper;

    public FacilityDepartmentAssignmentQueryHandlers(IGenericRepository<FacilityDepartmentAssignment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FacilityDepartmentAssignmentDto> Handle(GetFacilityDepartmentAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FacilityDepartmentAssignment not found.");
        return _mapper.Map<FacilityDepartmentAssignmentDto>(entity);
    }

    public async Task<IEnumerable<FacilityDepartmentAssignmentDto>> Handle(GetAllFacilityDepartmentAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FacilityDepartmentAssignmentDto>>(entities);
    }
}