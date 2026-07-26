using EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.CommitteeMembers;

public class GetCommitteeMemberByIdQuery : IRequest<CommitteeMemberDto>
{
    public long Id { get; set; }
}

public class GetAllCommitteeMembersQuery : IRequest<IEnumerable<CommitteeMemberDto>>
{
}