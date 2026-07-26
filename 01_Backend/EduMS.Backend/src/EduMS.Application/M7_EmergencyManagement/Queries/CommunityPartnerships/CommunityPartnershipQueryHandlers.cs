using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.CommunityPartnerships;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.CommunityPartnerships;

public class CommunityPartnershipQueryHandlers : 
    IRequestHandler<GetCommunityPartnershipByIdQuery, CommunityPartnershipDto>,
    IRequestHandler<GetAllCommunityPartnershipsQuery, IEnumerable<CommunityPartnershipDto>>
{
    private readonly IGenericRepository<CommunityPartnership> _repository;
    private readonly IMapper _mapper;

    public CommunityPartnershipQueryHandlers(IGenericRepository<CommunityPartnership> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CommunityPartnershipDto> Handle(GetCommunityPartnershipByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"CommunityPartnership not found.");
        return _mapper.Map<CommunityPartnershipDto>(entity);
    }

    public async Task<IEnumerable<CommunityPartnershipDto>> Handle(GetAllCommunityPartnershipsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CommunityPartnershipDto>>(entities);
    }
}