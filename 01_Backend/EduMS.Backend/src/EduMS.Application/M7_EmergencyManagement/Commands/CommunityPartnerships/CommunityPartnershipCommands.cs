using EduMS.Application.M7_EmergencyManagement.DTOs.CommunityPartnerships;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.CommunityPartnerships;

public class CreateCommunityPartnershipCommand : IRequest<long>
{
    public CreateCommunityPartnershipDto Dto { get; set; } = new();
}

public class UpdateCommunityPartnershipCommand : IRequest<bool>
{
    public UpdateCommunityPartnershipDto Dto { get; set; } = new();
}

public class DeleteCommunityPartnershipCommand : IRequest<bool>
{
    public long Id { get; set; }
}