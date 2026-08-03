using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.SelfServicePortalRequests;

public class SelfServicePortalRequestQueryHandlers : 
    IRequestHandler<GetSelfServicePortalRequestByIdQuery, SelfServicePortalRequestDto>,
    IRequestHandler<GetAllSelfServicePortalRequestsQuery, IEnumerable<SelfServicePortalRequestDto>>
{
    private readonly IGenericRepository<SelfServicePortalRequest> _repository;
    private readonly IMapper _mapper;

    public SelfServicePortalRequestQueryHandlers(IGenericRepository<SelfServicePortalRequest> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SelfServicePortalRequestDto> Handle(GetSelfServicePortalRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SelfServicePortalRequest not found.");
        return _mapper.Map<SelfServicePortalRequestDto>(entity);
    }

    public async Task<IEnumerable<SelfServicePortalRequestDto>> Handle(GetAllSelfServicePortalRequestsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SelfServicePortalRequestDto>>(entities);
    }
}