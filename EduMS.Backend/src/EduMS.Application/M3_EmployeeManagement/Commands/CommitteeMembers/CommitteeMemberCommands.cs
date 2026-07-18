using EduMS.Application.M3_EmployeeManagement.DTOs.CommitteeMembers;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.CommitteeMembers;

public class CreateCommitteeMemberCommand : IRequest<long>
{
    public CreateCommitteeMemberDto Dto { get; set; } = new();
}

public class UpdateCommitteeMemberCommand : IRequest<bool>
{
    public UpdateCommitteeMemberDto Dto { get; set; } = new();
}

public class DeleteCommitteeMemberCommand : IRequest<bool>
{
    public long Id { get; set; }
}