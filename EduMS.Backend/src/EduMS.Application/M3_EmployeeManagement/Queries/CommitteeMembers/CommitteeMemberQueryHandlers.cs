using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.CommitteeMembers;

public class CommitteeMemberQueryHandlers : 
    IRequestHandler<GetCommitteeMemberByIdQuery, CommitteeMemberDto>,
    IRequestHandler<GetAllCommitteeMembersQuery, IEnumerable<CommitteeMemberDto>>
{
    private readonly IGenericRepository<CommitteeMember> _repository;
    private readonly IMapper _mapper;

    public CommitteeMemberQueryHandlers(IGenericRepository<CommitteeMember> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CommitteeMemberDto> Handle(GetCommitteeMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"CommitteeMember not found.");
        return _mapper.Map<CommitteeMemberDto>(entity);
    }

    public async Task<IEnumerable<CommitteeMemberDto>> Handle(GetAllCommitteeMembersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CommitteeMemberDto>>(entities);
    }
}