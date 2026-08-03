using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.DirectorateExamCenterAssignments;

public class DirectorateExamCenterAssignmentQueryHandlers : 
    IRequestHandler<GetDirectorateExamCenterAssignmentByIdQuery, DirectorateExamCenterAssignmentDto>,
    IRequestHandler<GetAllDirectorateExamCenterAssignmentsQuery, IEnumerable<DirectorateExamCenterAssignmentDto>>
{
    private readonly IGenericRepository<DirectorateExamCenterAssignment> _repository;
    private readonly IMapper _mapper;

    public DirectorateExamCenterAssignmentQueryHandlers(IGenericRepository<DirectorateExamCenterAssignment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DirectorateExamCenterAssignmentDto> Handle(GetDirectorateExamCenterAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DirectorateExamCenterAssignment not found.");
        return _mapper.Map<DirectorateExamCenterAssignmentDto>(entity);
    }

    public async Task<IEnumerable<DirectorateExamCenterAssignmentDto>> Handle(GetAllDirectorateExamCenterAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DirectorateExamCenterAssignmentDto>>(entities);
    }
}