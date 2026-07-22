using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.UsageViolations;

public class UsageViolationQueryHandlers : 
    IRequestHandler<GetUsageViolationByIdQuery, UsageViolationDto>,
    IRequestHandler<GetAllUsageViolationsQuery, IEnumerable<UsageViolationDto>>
{
    private readonly IGenericRepository<UsageViolation> _repository;
    private readonly IMapper _mapper;

    public UsageViolationQueryHandlers(IGenericRepository<UsageViolation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UsageViolationDto> Handle(GetUsageViolationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"UsageViolation not found.");
        return _mapper.Map<UsageViolationDto>(entity);
    }

    public async Task<IEnumerable<UsageViolationDto>> Handle(GetAllUsageViolationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UsageViolationDto>>(entities);
    }
}