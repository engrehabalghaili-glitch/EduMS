using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassroomResourceAllocations;

public class ClassroomResourceAllocationQueryHandlers : 
    IRequestHandler<GetClassroomResourceAllocationByIdQuery, ClassroomResourceAllocationDto>,
    IRequestHandler<GetAllClassroomResourceAllocationsQuery, IEnumerable<ClassroomResourceAllocationDto>>
{
    private readonly IGenericRepository<ClassroomResourceAllocation> _repository;
    private readonly IMapper _mapper;

    public ClassroomResourceAllocationQueryHandlers(IGenericRepository<ClassroomResourceAllocation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClassroomResourceAllocationDto> Handle(GetClassroomResourceAllocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ClassroomResourceAllocation not found.");
        return _mapper.Map<ClassroomResourceAllocationDto>(entity);
    }

    public async Task<IEnumerable<ClassroomResourceAllocationDto>> Handle(GetAllClassroomResourceAllocationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ClassroomResourceAllocationDto>>(entities);
    }
}