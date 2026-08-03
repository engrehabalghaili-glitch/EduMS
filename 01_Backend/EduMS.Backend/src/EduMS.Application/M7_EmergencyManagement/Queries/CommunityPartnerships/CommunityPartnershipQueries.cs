using EduMS.Application.M7_EmergencyManagement.DTOs.CommunityPartnerships;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.CommunityPartnerships;

public class GetCommunityPartnershipByIdQuery : IRequest<CommunityPartnershipDto>
{
    public long Id { get; set; }
}

public class GetAllCommunityPartnershipsQuery : IRequest<IEnumerable<CommunityPartnershipDto>>
{
}