using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserRoleAssignments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserRoleAssignments;

public class UserRoleAssignmentQueryHandlers : 
    IRequestHandler<GetUserRoleAssignmentByIdQuery, UserRoleAssignmentDto>,
    IRequestHandler<GetAllUserRoleAssignmentsQuery, IEnumerable<UserRoleAssignmentDto>>
{
    private readonly IGenericRepository<UserRoleAssignment> _repository;
    private readonly IMapper _mapper;

    public UserRoleAssignmentQueryHandlers(IGenericRepository<UserRoleAssignment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserRoleAssignmentDto> Handle(GetUserRoleAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"UserRoleAssignment not found.");
        return _mapper.Map<UserRoleAssignmentDto>(entity);
    }

    public async Task<IEnumerable<UserRoleAssignmentDto>> Handle(GetAllUserRoleAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserRoleAssignmentDto>>(entities);
    }
}